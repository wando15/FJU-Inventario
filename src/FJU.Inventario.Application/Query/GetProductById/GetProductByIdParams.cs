using MediatR;

namespace FJU.Inventario.Application.Query.GetProductById
{
    public class GetProductByIdParams : IRequest<GetProductByIdResponse>
    {
        public string? Id { get; set; }
    }
}
