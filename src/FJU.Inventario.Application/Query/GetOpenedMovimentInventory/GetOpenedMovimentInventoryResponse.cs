using FJU.Inventario.Domain.Entities;

namespace FJU.Inventario.Application.Query.GetOpenedMovimentInventory
{
    public class GetOpenedMovimentInventoryResponse
    {
        public BaseResult<IList<MovimentInventoryEntity>>? Result { get; set; }
    }
}
