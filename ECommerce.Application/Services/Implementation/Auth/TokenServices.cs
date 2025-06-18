using ECommerce.Application.DTOs.UserDtos;
using ECommerce.Application.Services.Interfaces.Auth;
using ECommerce.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Services.Implementation.Auth
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration; // Correctly name the field to match the injected dependency.

        public TokenService(IConfiguration configuration) // Inject IConfiguration via constructor.
        {
            _configuration = configuration;
        }

        public async Task<string> GenerateTokenAsync(UserDto user)
        {
            var secretKey = _configuration.GetSection("Jwt:SecretKey").Value; // Use GetSection and Value instead of GetValue.
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
               {
                   new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                   new Claim(ClaimTypes.Email, user.Email),
                   new Claim(ClaimTypes.Role, user.Role.ToString())
               };

            var token = new JwtSecurityToken(
                issuer: _configuration.GetSection("Jwt:Issuer").Value, 
                audience: _configuration.GetSection("Jwt:Audience").Value,
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token); 
        }
    }
}
