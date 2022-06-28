using FJU.Inventario.Domain.Entities;
using System.Net;

namespace FJU.Inventario.Application.Query.GetProducts
{
    public class GetProductsResponse
    {
        public BaseResult<IList<ProductEntity>>? Result { get; set; }

        public static explicit operator GetProductsResponse(List<ProductEntity> input)
        {
            return new GetProductsResponse
            {
                Result = new BaseResult<IList<ProductEntity>>()
                {
                    IsSuccess = true,
                    Message = "these is products found",
                    StatusCode = HttpStatusCode.OK,
                    Result = input
                }
            };
        }
    }
}
