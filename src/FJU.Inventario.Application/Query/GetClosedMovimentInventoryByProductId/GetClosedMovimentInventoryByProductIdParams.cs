using MediatR;

namespace FJU.Inventario.Application.Query.GetClosedMovimentInventoryByProductId
{
    public class GetClosedMovimentInventoryByProductIdParams : IRequest<GetClosedMovimentInventoryByProductIdResponse>
    {
        public string? Id { get; set; }
    }
}
