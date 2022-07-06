namespace FJU.Inventario.Domain.Entities
{
    public class MovimentInventoryEntity : TEntity
    {
        public string? UserId { get; set; }
        public IList<ProductWithdrawalEntity> ProductsWithdrawal { get; set; }
        public IList<ProductReturnedEntity> ProductsReturned { get; set; }
        public DateTime Withdrawal { get; set; }
        public DateTime Returned { get; set; }
        public bool IsOpened { get; set; }
    }
}
