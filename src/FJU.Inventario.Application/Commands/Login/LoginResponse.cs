using FJU.Inventario.Domain.Entities;
using System.Net;

namespace FJU.Inventario.Application.Commands.Login
{
    public class LoginResponse
    {
        public BaseResult<String>? Result { get; set; }

        public static explicit operator LoginResponse(string token)
        {
            return new LoginResponse
            {
                Result = new BaseResult<string>
                {
                    IsSuccess = true,
                    Message = "Login Succesfuly",
                    StatusCode = HttpStatusCode.OK,
                    Result = token
                }
            };
        }
    }
}
