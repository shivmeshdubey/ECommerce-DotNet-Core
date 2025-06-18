using ECommerce.Application.Common;
using ECommerce.Application.DTOs.UserDtos;
using ECommerce.Application.Services.Interfaces.Auth;
using MediatR;

namespace ECommerce.Application.Features.UserCommandQueries.Query.GetUserById
{
    public class GetUserByIdorEmailQueryHandler : IRequestHandler<GetUserByIdorEmailQuery, Result<UserDto>>
    {
        public IUserServices UserServices;
        public GetUserByIdorEmailQueryHandler(IUserServices userServices)
        {
            UserServices = userServices;
        }
        public async Task<Result<UserDto>> Handle(GetUserByIdorEmailQuery query, CancellationToken cancellationToken)
        {
            var response = await UserServices.GetUserByEmailorIDAsync(query.getEorIdDto);
            if (response.Success)
            {
                return Result<UserDto>.Ok(response.Data);
            }
            return Result<UserDto>.Fail(response.Message);
        }
    }
}
