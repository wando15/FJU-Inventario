using FJU.Inventario.Domain.Entities;
using System.Net;

namespace FJU.Inventario.Application.Commands.CreateUser
{
    public class CreateUserResponse
    {
        public BaseResult<UserEntity>? Result { get; set; }

        public static explicit operator CreateUserResponse(UserEntity input)
        {
            return new CreateUserResponse
            {
                Result = new BaseResult<UserEntity>()
                {
                    IsSuccess = true,
                    Message = "Create User Successfoly",
                    StatusCode = HttpStatusCode.Created,
                    Result = input
                }
            };
        }
    }
}
