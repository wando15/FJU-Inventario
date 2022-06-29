using FJU.Inventario.Domain.Entities;
using System.Net;

namespace FJU.Inventario.Application.Query.GetClosedMovimentInventory
{
    public class GetClosedMovimentInventoryResponse
    {
        public BaseResult<IList<MovimentInventoryEntity>>? Result { get; set; }
    }
}
