using FJU.Inventario.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FJU.Inventario.Application.Commands.UpdateUser
{
    public class UpdateUserResponse
    {
        public BaseResult<UserEntity>? Result { get; set; }

        public static explicit operator UpdateUserResponse(UserEntity input)
        {
            return new UpdateUserResponse
            {
                Result = new BaseResult<UserEntity>()
                {
                    IsSuccess = true,
                    Message = "Updated User Successfoly",
                    StatusCode = HttpStatusCode.OK,
                    Result = new UserEntity
                    {
                        Id = input.Id,
                        UserName = input.UserName,
                        Name = input.Name,
                        IsCoordinator = input.IsCoordinator,
                        ProjectId = input.ProjectId,
                        IsActive = input.IsActive
                    }
                }
            };
        }
    }
}
