using FJU.Inventario.Domain.Entities;
using System.Net;

namespace FJU.Inventario.Application.Query.GetClosedMovimentInventory
{
    public class GetClosedMovimentInventoryResponse
    {
        public BaseResult<IList<MovimentInventoryEntity>>? Result { get; set; }

        public static explicit operator GetClosedMovimentInventoryResponse(List<MovimentInventoryEntity> input)
        {
            return new GetClosedMovimentInventoryResponse
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
