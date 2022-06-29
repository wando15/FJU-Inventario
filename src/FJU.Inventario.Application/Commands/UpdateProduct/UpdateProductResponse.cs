using FJU.Inventario.Domain.Entities;

namespace FJU.Inventario.Application.Commands.UpdateProduct
{
    public class UpdateProductResponse
    {
        public BaseResult<ProductEntity>? Result { get; set; }

        public static explicit operator UpdateProductResponse(ProductEntity input)
        {
            return new UpdateProductResponse
            {
                Result = new BaseResult<ProductEntity>
                {
                    IsSuccess = true,
                    Message = "Updated product successfoly",
                    StatusCode = System.Net.HttpStatusCode.OK,
                    Data = input
                }
            };
        }
    }
}
