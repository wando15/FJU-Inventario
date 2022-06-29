﻿using FJU.Inventario.Domain.Entities;
using System.Net;

namespace FJU.Inventario.Application.Commands.UpdateProject
{
    public class UpdateProjectResponse
    {
        public BaseResult<ProjectEntity>? Result { get; set; }

        public static explicit operator UpdateProjectResponse(ProjectEntity input)
        {
            return new UpdateProjectResponse
            {
                Result = new BaseResult<ProjectEntity>
                {
                    IsSuccess = true,
                    Message = "Create Project Successfoly",
                    StatusCode = HttpStatusCode.Created,
                    Data = input
                }
            };
        }
    }
}
