using FJU.Inventario.Domain.Entities;
using System.Net;

namespace FJU.Inventario.Application.Query.GetProductByProjectId
{
    public class GetProductByProjectIdResponse
    {
        public BaseResult<List<ProductEntity>>? Result { get; set; }

        public static explicit operator GetProductByProjectIdResponse(List<ProductEntity> input)
        {
            return new GetProductByProjectIdResponse
            {
                Result = new BaseResult<List<ProductEntity>>()
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
