using FJU.Inventario.Domain.Entities;
using System.Net;

namespace FJU.Inventario.Application.Query.GetProjects
{
    public class GetProjectsResponse
    {
        public BaseResult<List<ProjectEntity>>? Result { get; set; }

        public static explicit operator GetProjectsResponse(List<ProjectEntity> input)
        {
            return new GetProjectsResponse
            {
                Result = new BaseResult<List<ProjectEntity>>()
                {
                    IsSuccess = true,
                    Message = "these is projects found",
                    StatusCode = HttpStatusCode.OK,
                    Result = input.Select(x => new ProjectEntity
                    {
                        Id = x.Id,
                        Name = x.Name,
                        CoordinatorId = x.CoordinatorId
                    }).ToList()
                }
            };
        }
    }
}
