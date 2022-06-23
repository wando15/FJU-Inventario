namespace FJU.Inventario.Domain.Entities
{
    public class ProductEntity : TEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ProjectId { get; set; }
    }
}
