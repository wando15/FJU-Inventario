using FJU.Inventario.Domain.Entities;
using System.Net;

namespace FJU.Inventario.Application.Commands.CreateProduct
{
    public class CreateProductResponse
    {
        public BaseResult<ProductEntity>? Result { get; set; }

        public static explicit operator CreateProductResponse(ProductEntity input)
        {
            return new CreateProductResponse
            {
                Result = new BaseResult<ProductEntity>
                {
                    IsSuccess = true,
                    Message = "Create product successfoly",
                    StatusCode = HttpStatusCode.Created,
                    Result = input
                }
            };
        }
    }
}
