using ECommerce.Application.Common;
using ECommerce.Application.DTOs.UserDtos;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Services.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetUserByEmailAsync(string Email);
        Task AddAsync(User user);

        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<Result<string>> DeleteUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task<User?> GetUserByIdAsync(Guid? id);
    }
}
