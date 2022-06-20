using FJU.Inventario.Domain.Entities;
using System.Net;

namespace FJU.Inventario.Application.Commands.RemoveProject
{
    public class RemoveProjectResponse
    {
        public BaseResult<bool>? Result { get; set; }

        public static explicit operator RemoveProjectResponse(bool IsSuccess)
        {
            return new RemoveProjectResponse
            {
                Result = new BaseResult<bool>
                {
                    IsSuccess = IsSuccess,
                    Message = "Project deleted",
                    StatusCode = HttpStatusCode.OK,
                    Result = IsSuccess
                }
            };
        }
    }
}
