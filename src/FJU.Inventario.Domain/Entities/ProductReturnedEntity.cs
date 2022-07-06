namespace FJU.Inventario.Domain.Entities
{
    public class ProductReturnedEntity : TEntity
    {
        public string? ProductId { get; set; }
        public int AmmountReturned { get; set; }
    }
}
