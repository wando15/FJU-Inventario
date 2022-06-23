using FJU.Inventario.Domain.Entities;
using System.Net;

namespace FJU.Inventario.Application.Commands.CreateProject
{
    public class CreateProjectResponse
    {
        public BaseResult<ProjectEntity>? Result { get; set; }

        public static explicit operator CreateProjectResponse(ProjectEntity input)
        {
            return new CreateProjectResponse
            {
                Result = new BaseResult<ProjectEntity>
                {
                    IsSuccess = true,
                    Message = "Create Project Successfoly",
                    StatusCode = HttpStatusCode.Created,
                    Result = input
                }
            };
        }
    }
}
