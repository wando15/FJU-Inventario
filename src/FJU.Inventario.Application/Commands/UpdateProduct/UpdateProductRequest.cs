using FJU.Inventario.Domain.Entities;
using MediatR;

namespace FJU.Inventario.Application.Commands.UpdateProduct
{
    public class UpdateProductRequest : IRequest<UpdateProductResponse>
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ProjectId { get; set; }
        public int Ammount { get; set; }
        public int Available { get; set; }

        public static explicit operator ProductEntity(UpdateProductRequest input)
        {
            return new ProductEntity
            {
                Name = input.Name,
                Description = input.Description,
                ProjectId = input.ProjectId,
                Ammount = input.Ammount,
                Available = input.Available
                
            };
        }
    }
}
