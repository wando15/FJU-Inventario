namespace FJU.Inventario.Domain.Entities
{
    public class ProjectEntity : TEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? CoordinatorId { get; set; }
    }
}
