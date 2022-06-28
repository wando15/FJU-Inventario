using FJU.Inventario.Domain.Entities;

namespace FJU.Inventario.Application.Commands.MoveInventory
{
    public class MoveInventoryResponse
    {
        public BaseResult<MovimentInventoryEntity>? Result{ get; set; }

        public static explicit operator MoveInventoryResponse(MovimentInventoryEntity input)
        {
            return new MoveInventoryResponse
            {
                Result = new BaseResult<MovimentInventoryEntity>
                {
                    IsSuccess = true,
                    Message = "Products withdrawn successfully",
                    StatusCode = System.Net.HttpStatusCode.OK,
                    Result = input
                }
            };
        }
    }
}
