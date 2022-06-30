namespace FJU.Inventario.Domain.Entities
{
    public class AccessToken
    {
        public string? UserId { get; set; }
        public string? UserName { get; set; }
        public DateTime Validate { get; set; }
    }
}
