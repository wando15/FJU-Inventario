using FJU.Inventario.Domain.Entities;
using System.Net;

namespace FJU.Inventario.Application.Query.GetProjects
{
    public class GetProjectsResponse
    {
        public BaseResult<IList<ProjectEntity>>? Result { get; set; }

        public static explicit operator GetProjectsResponse(List<ProjectEntity> input)
        {
            return new GetProjectsResponse
            {
                Result = new BaseResult<IList<ProjectEntity>>()
                {
                    IsSuccess = true,
                    Message = "these is projects found",
                    StatusCode = HttpStatusCode.OK,
                    Result = input
                }
            };
        }
    }
}
