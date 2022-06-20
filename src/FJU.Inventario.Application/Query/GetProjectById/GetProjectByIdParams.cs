using MediatR;

namespace FJU.Inventario.Application.Query.GetProjectById
{
    public class GetProjectByIdParams : IRequest<GetProjectByIdResponse>
    {
        public string? Id { get; set; }
    }
}
