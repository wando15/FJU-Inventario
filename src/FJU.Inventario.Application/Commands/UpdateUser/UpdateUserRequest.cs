using FJU.Inventario.Domain.Entities;
using MediatR;
using System.Text.Json.Serialization;

namespace FJU.Inventario.Application.Commands.UpdateUser
{
    public class UpdateUserRequest : IRequest<UpdateUserResponse>
    {
        [JsonIgnore]
        public string? Id { get; set; }
        public string? UserName { get; set; }
        public string? Name { get; set; }
        [JsonIgnore]
        public string? Password { get; set; }
        public string? ProjectId { get; set; }
        public bool IsCoordinator { get; set; }
        public bool IsActive { get; set; } = true;

        public static explicit operator UserEntity(UpdateUserRequest input)
        {
            return new UserEntity
            {
                UserName = input.UserName,
                Name = input.Name,
                Password = input.Password,
                ProjectId = input.ProjectId,
                IsCoordinator = input.IsCoordinator,
                IsActive = input.IsActive
            };
        }
    }
}
