using ECommerce.Application.Common;
using ECommerce.Application.DTOs.UserDtos;
using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Services.Interfaces.Auth
{
    public interface IUserServices
    {
        Task<Result<string>> ResisterAsync(UserResisterDto dto);
        Task<Result<string>> LoginAsync(UserLoginDto dto);

        Task<List<UserDto>> GetAllUsersAsync();
        Task<Result<string>> DeleteUserAsync(GetUserByIdorEmailDto dto);
        Task<UserDto> GetUserByEmailAsync(string email);
        Task<Result<UserDto>> GetUserByEmailorIDAsync(GetUserByIdorEmailDto dto);
        Task<User> GetUserByIdAsync(Guid id);
        Task<Result<string>> UpdateUserAsync(UserDto user);
        //Task<Result<string>> ChangePasswordAsync(ChangePasswordDto changePasswordDto);
        //Task<Result<string>> ForgotPasswordAsync(ForgotPasswordDto forgotPasswordDto);
        Task<Result<string>> ValidateUserCredentials( string email,string password);
    }
}
