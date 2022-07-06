using FJU.Inventario.Domain.Entities;
using MediatR;
using System.Text.Json.Serialization;

namespace FJU.Inventario.Application.Commands.MoveInventory
{
    public class MoveInventoryRequest : IRequest<MoveInventoryResponse>
    {
        [JsonIgnore]
        public string? UserId { get; set; }
        public IList<ProductWithdrawal>? Products { get; set; }

        public static explicit operator MovimentInventoryEntity(MoveInventoryRequest input)
        {
            return new MovimentInventoryEntity
            {
                ProductsWithdrawal = input.Products.Select(x => new ProductWithdrawalEntity
                {
                    ProductId = x.ProductId,
                    AmmountWithdrawal = x.AmmountWithdrawal,
                }).ToList(),
                UserId = input.UserId,
                Withdrawal = DateTime.UtcNow,
                IsOpened = true
            };
        }
    }

    public class ProductWithdrawal
    {
        public string? ProductId { get; set; }
        public int AmmountWithdrawal { get; set; }

    }
}
