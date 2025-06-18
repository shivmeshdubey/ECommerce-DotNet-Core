using ECommerce.Application.Common;
using ECommerce.Application.DTOs.CategoryDto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Category.Query.QueryIRequest
{
    public class CategoryByIdQuery : IRequest<Result<CategoryDto>>
    {
        public Guid Id { get; set; }
        public CategoryByIdQuery(Guid Id)
        {
            this.Id = Id;
        }
    }
}
