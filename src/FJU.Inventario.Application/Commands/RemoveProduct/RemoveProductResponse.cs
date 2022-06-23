using FJU.Inventario.Domain.Entities;
using System.Net;

namespace FJU.Inventario.Application.Commands.RemoveProduct
{
    public class RemoveProductResponse
    {
        public BaseResult<bool>? Result { get; set; }

        public static explicit operator RemoveProductResponse(bool IsSuccess)
        {
            return new RemoveProductResponse
            {
                Result = new BaseResult<bool>
                {
                    IsSuccess = IsSuccess,
                    Message = "Project deleted",
                    StatusCode = HttpStatusCode.OK,
                    Result = IsSuccess
                }
            };
        }
    }
}
