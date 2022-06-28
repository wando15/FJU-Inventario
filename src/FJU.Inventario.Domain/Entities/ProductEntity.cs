namespace FJU.Inventario.Domain.Entities
{
    public class ProductEntity : TEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ProjectId { get; set; }
        public int Ammount { get; set; }
        public int Available { get; set; }
        public int Unavailable { get; set; }
    }
}
