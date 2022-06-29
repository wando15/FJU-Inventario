using MediatR;

namespace FJU.Inventario.Application.Commands.ReturnedInventory
{
    public class ReturnedInventoryRequest : IRequest<ReturnedInventoryResponse>
    {
        public string? Id { get; set; }
        public IList<ProductReturned>? Products { get; set; }
    }

    public class ProductReturned
    {
        public string? ProductId { get; set; }
        public int AmmountReturned { get; set; }

    }
}
