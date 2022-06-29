using FJU.Inventario.Domain.Entities;
using System.Net;

namespace FJU.Inventario.Application.Query.GetOpenedMovimentInventory
{
    public class GetOpenedMovimentInventoryResponse
    {
        public BaseResult<IList<MovimentInventoryEntity>>? Result { get; set; }
    }
}
