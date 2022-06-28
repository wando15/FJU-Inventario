using FJU.Inventario.Domain.Entities;
using MediatR;

namespace FJU.Inventario.Application.Commands.MoveInventory
{
    public class MoveInventoryRequest : IRequest<MoveInventoryResponse>
    {
        public string? UserId { get; set; }
        public string? ProductId { get; set; }
        public int AmmountWithdrawal { get; set; }

        public static explicit operator MovimentInventoryEntity(MoveInventoryRequest input)
        {
            return new MovimentInventoryEntity
            {
                ProductId = input.ProductId,
                UserId = input.UserId,
                AmmountWithdrawal = input.AmmountWithdrawal,
                Withdrawal = DateTime.UtcNow,
                IsOpened = true
            };
        }
    }
}
