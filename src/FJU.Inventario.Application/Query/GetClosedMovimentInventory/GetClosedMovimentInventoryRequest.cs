using MediatR;
using Microsoft.Extensions.Primitives;

namespace FJU.Inventario.Application.Query.GetClosedMovimentInventory
{
    public class GetClosedMovimentInventoryRequest : IRequest<GetClosedMovimentInventoryResponse>
    {
        public GetClosedMovimentInventoryRequest(StringValues? userId)
        {
            UserId = userId;
        }

        public string UserId { get; internal set; }
    }
}
