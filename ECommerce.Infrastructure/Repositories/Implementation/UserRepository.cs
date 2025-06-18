using ECommerce.Application.Common;
using ECommerce.Application.DTOs.UserDtos;
using ECommerce.Application.Services.Interfaces;
using ECommerce.Domain.Entities;
using ECommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infrastructure.Repositories.Implementation
{
    public class UserRepository : IUserRepository
    {
        public AppDbContext appdbContext { get; set; }
        public UserRepository(AppDbContext appdbContext) { this.appdbContext = appdbContext; }
        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await appdbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User?> GetUserByIdAsync(Guid? id)
        {
            return await appdbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await appdbContext.Users.ToListAsync();
        }

        public async Task AddAsync(User user)
        {
            await appdbContext.Users.AddAsync(user);
            await appdbContext.SaveChangesAsync();
        }
        public async Task<Result<string>> DeleteUserAsync(User user)
        {
            appdbContext.Users.Remove(user);
            await appdbContext.SaveChangesAsync();
            return Result<string>.Ok("user has been deleted");
        }

        public async Task UpdateUserAsync(User user)
        {
            appdbContext.Users.Update(user);
            appdbContext.Entry(user).State = EntityState.Modified;
            await appdbContext.SaveChangesAsync();
        }

        
    }
}
