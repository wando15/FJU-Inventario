using MediatR;

namespace FJU.Inventario.Application.Query.GetOpenedMovimentInventory
{
    public class GetOpenedMovimentInventoryRequest : IRequest<GetOpenedMovimentInventoryResponse>
    {
        public GetOpenedMovimentInventoryRequest(string? userId)
        {
            UserId = userId;
        }

        public string? UserId { get; }
    }
}
