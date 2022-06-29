using FJU.Inventario.Domain.Entities;
using System.Net;

namespace FJU.Inventario.Application.Query.GetProductById
{
    public class GetProductByIdResponse
    {
        public BaseResult<ProductEntity>? Result { get; set; }

        public static explicit operator GetProductByIdResponse(ProductEntity input)
        {
            return new GetProductByIdResponse
            {
                Result = new BaseResult<ProductEntity>()
                {
                    IsSuccess = true,
                    Message = "these is product found",
                    StatusCode = HttpStatusCode.OK,
                    Data = input,
                }
            };
        }
    }
}
