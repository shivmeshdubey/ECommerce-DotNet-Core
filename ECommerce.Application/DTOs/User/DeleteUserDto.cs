using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.DTOs.User
{
    public class DeleteUserDto
    {
        public Guid Id { get; set; }
        public string Email {  get; set; }
    }
}
