using FJU.Inventario.Domain.Entities;
using MediatR;

namespace FJU.Inventario.Application.Commands.RemoveProject
{
    public class RemoveProjectParams : IRequest<RemoveProjectResponse>
    {
        public string? Id { get; set; }
    }
}
