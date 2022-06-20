using MediatR;

namespace FJU.Inventario.Application.Query.GetProjects
{
    public class GetProjectsRequest : IRequest<GetProjectsResponse>
    {
        public string? Id { get; set; }
    }
}
