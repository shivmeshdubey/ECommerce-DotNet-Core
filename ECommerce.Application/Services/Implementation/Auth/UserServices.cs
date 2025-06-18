using ECommerce.Application.Common;
using ECommerce.Application.DTOs.UserDtos;
using ECommerce.Application.Services.Interfaces;
using ECommerce.Application.Services.Interfaces.Auth;
using ECommerce.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace ECommerce.Application.Services.Implementation.Auth
{
    public class UserServices : IUserServices
    {
        public IUserRepository UserRepository { get; set; }
        public IPasswordHasher<User> passwordHasher { get; set; }
        
        public UserServices(IUserRepository UserRepository)
        {
            this.UserRepository = UserRepository;
            passwordHasher = new PasswordHasher<User>();

        }

        public Task<Result<string>> LoginAsync(UserLoginDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<string>> ValidateUserCredentials(string email, string password)
        {
            var user = await UserRepository.GetUserByEmailAsync(email);
            if (user == null)
            {
                return Result<string>.Fail("Invalid email or password");
            }
            var passwordVerificationResult = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);
            if (passwordVerificationResult == PasswordVerificationResult.Failed)
            {
                return Result<string>.Fail("Invalid email or password");
            }
            return Result<string>.Ok(user.Id.ToString(), "valid  User");
        }

        public async Task<Result<string>> ResisterAsync(UserResisterDto dto)
        {
            //check user exist or not...
            var user = await UserRepository.GetUserByEmailAsync(dto.Email);
            if (user != null)
            {
                return Result<string>.Fail("Given User is already exist");
            }
            user = new User
            {
                Id = Guid.NewGuid(),
                UserName = dto.UserName,
                Email = dto.Email,
                PasswordHash = dto.Password,
                Role = dto.Role
            };

            user.PasswordHash = passwordHasher.HashPassword(user, user.PasswordHash);

            await UserRepository.AddAsync(user);

            return Result<string>.Ok(user.Id.ToString(), "User Registered!");
        }

        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            var users = await UserRepository.GetAllUsersAsync();

            return users.Select(user => new UserDto
            {
                Id= user.Id,
                FullName = user.UserName,
                Email = user.Email,
                Role = user.Role,
            }).ToList();
        }

        public async Task<Result<string>> DeleteUserAsync(GetUserByIdorEmailDto dto)
        {
            User user = null;
            if (dto.Id != null)
            {
                 user = await UserRepository.GetUserByIdAsync(dto.Id);
            }
            if (user == null && dto.Email !=null)
            {
                user = await UserRepository.GetUserByEmailAsync(dto.Email);
            }
            if(user == null)
            {
                return Result<string>.Fail("Unable to delete this user");
            }
            var response = await UserRepository.DeleteUserAsync(user);
            if(response.Success)
            {
                return Result<string>.Ok(response.Data);
            }else
            {
                return Result<string>.Fail("Unable to delete this user");
            }
        }

        public async Task<UserDto> GetUserByEmailAsync(string email)
        {
            var user = await UserRepository.GetUserByEmailAsync(email);
            return new UserDto
            {
                Id = user.Id,
                FullName = user.UserName,
                Email = user.Email,
                Role = user.Role,
            };
        }
        public async Task<Result<UserDto>> GetUserByEmailorIDAsync(GetUserByIdorEmailDto dto)
        {
            User user = new User();


            if (dto.Email != null)
            {
                user = await UserRepository.GetUserByEmailAsync(dto.Email);
            }
            if (dto.Id != null)
            {
                user = await UserRepository.GetUserByIdAsync(dto.Id);
                
            }

            if(user != null)
            {
                return Result<UserDto>.Ok(new UserDto
                {
                    Id = user.Id,
                    FullName = user.UserName,
                    Email = user.Email,
                    Role = user.Role,
                });

            }
            else
            {
                return Result<UserDto>.Fail("not found");
            }
        }

        public async Task<Result<string>> UpdateUserAsync(UserDto user)
        {
            var dto = new GetUserByIdorEmailDto
            {
                Id = user.Id,
                Email = user.Email,
            };
            var data = await this.GetUserByEmailorIDAsync(dto);
            if (data.Success)
            {
                await UserRepository.UpdateUserAsync(new User
                {
                    UserName = user.FullName,
                    Email = user.Email,
                    Role=user.Role,
                });
                return Result<string>.Ok(data.Data.ToString(), "Updated");
            }
            return Result<string>.Fail(data.Message);
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            return await UserRepository.GetUserByIdAsync(id);
        }
    }
}
