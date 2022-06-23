using FJU.Inventario.Domain.Entities;
using MediatR;

namespace FJU.Inventario.Application.Commands.CreateProduct
{
    public class CreateProductRequest : IRequest<CreateProductResponse>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ProjectId { get; set; }

        public static explicit operator ProductEntity(CreateProductRequest input)
        {
            return new ProductEntity
            {
                Name = input.Name,
                Description = input.Description,
                ProjectId = input.ProjectId
            };
        }
    }
}
