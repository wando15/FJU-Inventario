using MediatR;

namespace FJU.Inventario.Application.Commands.Login
{
    public class LoginRequest : IRequest<LoginResponse>
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
}
