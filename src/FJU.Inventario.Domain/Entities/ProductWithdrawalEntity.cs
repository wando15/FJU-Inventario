﻿namespace FJU.Inventario.Domain.Entities
{
    public class ProductWithdrawalEntity : TEntity
    {
        public string? ProductId { get; set; }
        public int AmmountWithdrawal { get; set; }
    }
}
