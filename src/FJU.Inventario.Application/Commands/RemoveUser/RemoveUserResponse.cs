using FJU.Inventario.Domain.Entities;
using System.Net;

namespace FJU.Inventario.Application.Commands.RemoveUser
{
    public class RemoveUserResponse
    {
        public BaseResult<bool>? Result { get; set; }

        public static explicit operator RemoveUserResponse(bool IsSuccess)
        {
            return new RemoveUserResponse
            {
                Result = new BaseResult<bool>
                {
                    IsSuccess = IsSuccess,
                    Message = "User deleted",
                    StatusCode = HttpStatusCode.OK,
                    Result = IsSuccess
                }
            };
        }
    }
}
