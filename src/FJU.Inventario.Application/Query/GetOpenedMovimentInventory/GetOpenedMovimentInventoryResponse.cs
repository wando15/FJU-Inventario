using FJU.Inventario.Domain.Entities;
using System.Net;

namespace FJU.Inventario.Application.Query.GetOpenedMovimentInventory
{
    public class GetOpenedMovimentInventoryResponse
    {
        public BaseResult<IList<MovimentInventoryEntity>>? Result { get; set; }

        public static explicit operator GetOpenedMovimentInventoryResponse(List<MovimentInventoryEntity> input)
        {
            return new GetOpenedMovimentInventoryResponse
            {
                Result = new BaseResult<IList<MovimentInventoryEntity>>()
                {
                    IsSuccess = true,
                    Message = "these is open moves found",
                    StatusCode = HttpStatusCode.OK,
                    Result = input,
                }
            };
        }
    }
}
