using FJU.Inventario.Domain.Entities;
using System.Net;

namespace FJU.Inventario.Application.Commands.UpdateUser
{
    public class UpdateUserResponse
    {
        public BaseResult<UserEntity>? Result { get; set; }

        public static explicit operator UpdateUserResponse(UserEntity input)
        {
            return new UpdateUserResponse
            {
                Result = new BaseResult<UserEntity>()
                {
                    IsSuccess = true,
                    Message = "Updated User Successfoly",
                    StatusCode = HttpStatusCode.OK,
                    Data = input
                }
            };
        }
    }
}
