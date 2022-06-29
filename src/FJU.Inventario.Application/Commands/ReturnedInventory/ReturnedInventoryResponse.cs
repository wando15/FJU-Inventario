using FJU.Inventario.Domain.Entities;

namespace FJU.Inventario.Application.Commands.ReturnedInventory
{
    public class ReturnedInventoryResponse
    {
        public BaseResult<bool>? Result { get; set; }

        public static explicit operator ReturnedInventoryResponse(bool input)
        {
            return new ReturnedInventoryResponse
            {
                Result = new BaseResult<bool>
                {
                    IsSuccess = true,
                    Message = "Products withdrawn successfully",
                    StatusCode = System.Net.HttpStatusCode.OK,
                    Data = input
                }
            };
        }
    }
}
