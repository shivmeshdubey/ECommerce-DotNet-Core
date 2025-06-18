using ECommerce.Application.Features.Auth.Commands.RegisterUser;
using ECommerce.Application.Features.UserCommandQueries.Query.GetAllUser;
using ECommerce.Application.Features.UserCommandQueries.Query.GetUserById;
using ECommerce.Application.Services;
using ECommerce.Application.Services.Implementation.Auth;
using ECommerce.Application.Services.Implementation.CartServisesImplimentation;
using ECommerce.Application.Services.Implementation.CategoryServices;
using ECommerce.Application.Services.Implementation.OrderServices;
using ECommerce.Application.Services.Implementation.ProductsServices;
using ECommerce.Application.Services.Interfaces;
using ECommerce.Application.Services.Interfaces.Auth;
using ECommerce.Domain.Entities;
using ECommerce.Infrastructure.Data;
using ECommerce.Infrastructure.Repositories.Implementation;
using ECommerce.Infrastructure.Repositories.Implementation.CartRepositorImplementations;
using ECommerce.Infrastructure.Repositories.Implementation.CategoryRepo;
using ECommerce.Infrastructure.Repositories.Implementation.OrderRepo;
using ECommerce.Infrastructure.Repositories.Implementation.Products;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;


namespace ECommerce.API.DependencyInjection
{
    public static class ServicecollectionExtentions
    {
        public static IServiceCollection AddServices(this IServiceCollection services,IConfiguration configuration)
        {
            // Services
            services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<ICategoryServices, CategoryServices>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductService, ProductServices>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderService, OrderServices>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

            services.AddControllers();


            // MediatR v12 setup (or revert to older syntax if using v11)
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            // If your handlers are in another project (example: ECommerce.Application)
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(RegisterUserCommandHandeller).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(UserQueryHandller).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetUserByIdorEmailQueryHandler).Assembly));

            var secretKey = configuration.GetSection("Jwt:SecretKey").Value;
            //JWT Authentication....
            services.AddAuthentication("Bearer")
            .AddJwtBearer("Bearer", options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration.GetSection("Jwt:Issuer").Value,
                    ValidAudience = configuration.GetSection("Jwt:Audience").Value,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(secretKey))
                };
            });
            services.AddAuthentication();
            services.AddAuthorization();
            // DB Context
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            return services;

        }
    }
}
