namespace FJU.Inventario.Domain.Entities
{
    public class MovimentInventoryEntity : TEntity
    {
        public string? UserId { get; set; }
        public string? ProductId { get; set; }
        public int AmmountWithdrawal { get; set; }
        public int AmmountReturned { get; set; }
        public DateTime Withdrawal { get; set; }
        public DateTime Returned { get; set; }
        public bool IsOpened { get; set; }
    }
}
