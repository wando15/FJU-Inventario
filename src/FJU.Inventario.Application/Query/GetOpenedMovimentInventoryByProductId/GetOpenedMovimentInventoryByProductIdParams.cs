using MediatR;

namespace FJU.Inventario.Application.Query.GetOpenedMovimentInventoryByProductId
{
    public class GetOpenedMovimentInventoryByProductIdParams : IRequest<GetOpenedMovimentInventoryByProductIdResponse>
    {
        public string? Id { get; set; }
    }
}
