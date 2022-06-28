using MediatR;

namespace FJU.Inventario.Application.Commands.ReturnedInventory
{
    public class ReturnedInventoryRequest : IRequest<ReturnedInventoryResponse>
    {
        public string? Id { get; set; }
        public int AmmountReturned { get; set; }
        public DateTime Returned { get; set; }
    }
}
