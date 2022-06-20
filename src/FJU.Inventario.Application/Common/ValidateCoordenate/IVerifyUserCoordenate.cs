namespace FJU.Inventario.Application.Common.ValidateCoordenate
{
    public interface IVerifyUserCoordenate
    {
        Task<bool> IsCoordenate(string CoordinatorId);
    }
}
