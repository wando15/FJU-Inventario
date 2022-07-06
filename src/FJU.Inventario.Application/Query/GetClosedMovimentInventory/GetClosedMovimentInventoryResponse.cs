using FJU.Inventario.Domain.Entities;

namespace FJU.Inventario.Application.Query.GetClosedMovimentInventory
{
    public class GetClosedMovimentInventoryResponse
    {
        public BaseResult<IList<MovimentInventoryEntity>>? Result { get; set; }
    }
}
