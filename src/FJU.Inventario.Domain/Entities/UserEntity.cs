using System.Text.Json.Serialization;

namespace FJU.Inventario.Domain.Entities
{
    public class UserEntity : TEntity
    {
        public string? Name { get; set; }
        public string? UserName { get; set; }
        [JsonIgnore]
        public string? Password { get; set; }
        public string? ProjectId { get; set; }
        public bool IsCoordinator { get; set; }
        public bool IsActive { get; set; }
    }
}
