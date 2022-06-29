using FJU.Inventario.Domain.Entities;

namespace FJU.Inventario.Application.Query.GetClosedMovimentInventoryByProductId
{
    public class GetClosedMovimentInventoryByProductIdResponse
    {
        public BaseResult<IList<MovimentInventoryEntity>>? Result { get; set; }

        public static explicit operator GetClosedMovimentInventoryByProductIdResponse(List<MovimentInventoryEntity> input)
        {
            return new GetClosedMovimentInventoryByProductIdResponse
            {
                Result = new BaseResult<IList<MovimentInventoryEntity>>
                {
                    IsSuccess = true,
                    Message = "These is moves Inventory found",
                    StatusCode = System.Net.HttpStatusCode.OK,
                    Data = input
                }
            };
        }
    }
}
