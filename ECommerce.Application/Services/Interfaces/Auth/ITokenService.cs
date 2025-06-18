using ECommerce.Application.DTOs.UserDtos;
using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Services.Interfaces.Auth
{

    public interface ITokenService
    {
       Task<string> GenerateTokenAsync(UserDto user);
    }

  
}
