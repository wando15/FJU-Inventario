using MediatR;

namespace FJU.Inventario.Application.Query.GetUserById
{
    public class GetUserByIdParams : IRequest<GetUserByIdResponse>
    {
        public string? Id { get; set; }
    }
}
