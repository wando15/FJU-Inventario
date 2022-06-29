using MediatR;

namespace FJU.Inventario.Application.Commands.RemoveProduct
{
    public class RemoveProductParams : IRequest<RemoveProductResponse>
    {
        public string? Id { get; set; }
    }
}
