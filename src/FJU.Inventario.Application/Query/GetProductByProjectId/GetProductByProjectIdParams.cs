using MediatR;

namespace FJU.Inventario.Application.Query.GetProductByProjectId
{
    public class GetProductByProjectIdParams : IRequest<GetProductByProjectIdResponse>
    {
        public string? Id { get; set; }
    }
}
