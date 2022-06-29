using FJU.Inventario.Domain.Entities;
using System.Net;

namespace FJU.Inventario.Application.Commands.ForgotPassword
{
    public class ForgotPasswordResponse
    {
        public BaseResult<bool>? Result { get; set; }

        public static explicit operator ForgotPasswordResponse(bool IsSuccess)
        {
            return new ForgotPasswordResponse
            {
                Result = new BaseResult<bool>
                {
                    IsSuccess = IsSuccess,
                    Message = "User deleted",
                    StatusCode = HttpStatusCode.OK,
                    Data = IsSuccess
                }
            };
        }
    }
}
