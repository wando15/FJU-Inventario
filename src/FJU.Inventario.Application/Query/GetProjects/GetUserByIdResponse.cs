using FJU.Inventario.Domain.Entities;
using System.Net;

namespace FJU.Inventario.Application.Query.GetProjects
{
    public class GetProjectsResponse
    {
        public BaseResult<IList<ProjectEntity>>? Result { get; set; }
    }
}
