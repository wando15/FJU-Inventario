using FJU.Inventario.Domain.Entities;
using MediatR;

namespace FJU.Inventario.Application.Commands.CreateProject
{
    public class CreateProjectRequest : IRequest<CreateProjectResponse>
    {
        public string? Name { get; set; }
        public string? CoordinatorId { get; set; }
        public string? Description { get; set; }

        public static explicit operator ProjectEntity(CreateProjectRequest input)
        {
            return new ProjectEntity
            {
                CoordinatorId = input.CoordinatorId,
                Name = input.Name,
                Description = input.Description
            };
        }
    }
}
