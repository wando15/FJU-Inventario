using MediatR;

namespace FJU.Inventario.Application.Commands.ForgotPassword
{
    public class ForgotPasswordRequest : IRequest<ForgotPasswordResponse>
    {
        public string? Id { get; set; }
        public string? NewPassword { get; set; }
    }
}
