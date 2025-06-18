using ECommerce.Application.Common;
using ECommerce.Domain.Entities;
using ECommerce.Application.Services.Interfaces.Auth;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ECommerce.Application.Features.Auth.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, Result<string>>
    {
        private readonly IUserServices _userService;
        private readonly ITokenService _tokenService;

        public LoginUserCommandHandler(IUserServices userService, ITokenService tokenService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
        }

        public async Task<Result<string>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var loginDto = request.LoginDto ?? throw new ArgumentNullException(nameof(request.LoginDto), "Login DTO cannot be null");
            // Validate the user credentials
            var validationResult = await _userService.ValidateUserCredentials(loginDto.Email, loginDto.Password);
            if (validationResult.Success)
            {
                // Generate JWT token for the user
                var user = await _userService.GetUserByEmailAsync(loginDto.Email);
                string token = await _tokenService.GenerateTokenAsync(user);
                return Result<string>.Ok(token);
            }
            else
            {
                // Return failure result with error message
                return Result<string>.Fail(validationResult.Message);
                throw new NotImplementedException();
            }
        }
    }
}
