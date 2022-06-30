namespace FJU.Inventario.Application.Common.ValidatePermision
{
    public interface IVerifyPermission
    {
        Task<bool> IsAdmin();
        Task<bool> IsCoordenate();
    }
}
