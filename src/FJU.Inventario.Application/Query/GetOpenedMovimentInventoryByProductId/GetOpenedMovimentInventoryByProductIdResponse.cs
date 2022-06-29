using FJU.Inventario.Domain.Entities;

namespace FJU.Inventario.Application.Query.GetOpenedMovimentInventoryByProductId
{
    public class GetOpenedMovimentInventoryByProductIdResponse
    {
        public BaseResult<IList<MovimentInventoryEntity>>? Result { get; set; }

        public static explicit operator GetOpenedMovimentInventoryByProductIdResponse(List<MovimentInventoryEntity> input)
        {
            return new GetOpenedMovimentInventoryByProductIdResponse
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
