using FJU.Inventario.Domain.Entities;

namespace FJU.Inventario.Application.Common
{
    public interface ITokenService
    {
        Task<string> GenerateToken(UserEntity user);
    }
}
