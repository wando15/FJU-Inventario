﻿using FJU.Inventario.Domain.Entities;
using System.Net;

namespace FJU.Inventario.Application.Query.GetUserById
{
    public class GetUserByIdResponse
    {
        public BaseResult<UserEntity>? Result { get; set; }

        public static explicit operator GetUserByIdResponse(UserEntity input)
        {
            return new GetUserByIdResponse
            {
                Result = new BaseResult<UserEntity>()
                {
                    IsSuccess = true,
                    Message = "these is user found",
                    StatusCode = HttpStatusCode.OK,
                    Data = input
                }
            };
        }
    }
}
