using FJU.Inventario.Domain.Entities;
using MediatR;

namespace FJU.Inventario.Application.Commands.CreateUser
{
    public class CreateUserRequest : IRequest<CreateUserResponse>
    {
        public string? UserName { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
        public string? ProjectId { get; set; }
        public bool IsCoordinator { get; set; }

        public static explicit operator UserEntity(CreateUserRequest input)
        {
            return new UserEntity
            {
                UserName = input.UserName,
                Name = input.Name,
                Password = input.Password,
                ProjectId = input.ProjectId,
                IsCoordinator = input.IsCoordinator,
                IsActive = true
            };
        }
    }
}
