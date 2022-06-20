﻿using FJU.Inventario.Domain.Entities;
using System.Net;

namespace FJU.Inventario.Application.Query.GetUsers
{
    public class GetUsersResponse
    {
        public BaseResult<IList<UserEntity>>? Result { get; set; }

        public static explicit operator GetUsersResponse(List<UserEntity> input)
        { 
            return new GetUsersResponse
            {
                Result = new BaseResult<IList<UserEntity>>
                {
                    IsSuccess = true,
                    Message = "These are the users found",
                    StatusCode = HttpStatusCode.OK,
                    Result = input.Select(x => new UserEntity
                    {
                        Id = x.Id,
                        UserName = x.UserName,
                        Name = x.Name,
                        IsCoordinator = x.IsCoordinator,
                        ProjectId = x.ProjectId,
                        IsActive = x.IsActive
                    }).ToList()
                }
            };
        }
    }
}