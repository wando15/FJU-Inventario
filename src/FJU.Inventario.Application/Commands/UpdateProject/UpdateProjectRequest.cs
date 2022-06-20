using FJU.Inventario.Domain.Entities;
using MediatR;
using System.Text.Json.Serialization;

namespace FJU.Inventario.Application.Commands.UpdateProject
{
    public class UpdateProjectRequest : IRequest<UpdateProjectResponse>
    {
        [JsonIgnore]
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? CoordinatorId { get; set; }
        public string? Description { get; set; }

        public static explicit operator ProjectEntity(UpdateProjectRequest input)
        {
            return new ProjectEntity
            {
                Id = input.Id,
                CoordinatorId = input.CoordinatorId,
                Name = input.Name,
                Description = input.Description
            };
        }
    }
}
