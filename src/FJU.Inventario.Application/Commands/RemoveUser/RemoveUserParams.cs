using FJU.Inventario.Domain.Entities;
using MediatR;

namespace FJU.Inventario.Application.Commands.RemoveUser
{
    public class RemoveUserParams : IRequest<RemoveUserResponse>
    {
        public string? Id { get; set; }
    }
}
