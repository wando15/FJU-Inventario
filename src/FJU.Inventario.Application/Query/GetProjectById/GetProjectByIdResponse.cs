using FJU.Inventario.Domain.Entities;
using System.Net;

namespace FJU.Inventario.Application.Query.GetProjectById
{
    public class GetProjectByIdResponse
    {
        public BaseResult<ProjectEntity>? Result { get; set; }

        public static explicit operator GetProjectByIdResponse(ProjectEntity input)
        {
            return new GetProjectByIdResponse
            {
                Result = new BaseResult<ProjectEntity>()
                {
                    IsSuccess = true,
                    Message = "these is project found",
                    StatusCode = HttpStatusCode.OK,
                    Data = input
                }
            };
        }
    }
}
