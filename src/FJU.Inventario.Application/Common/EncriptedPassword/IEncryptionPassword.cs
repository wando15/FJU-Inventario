namespace FJU.Inventario.Application.Common.EncriptedPassword
{
    public interface IEncryptionPassword
    {
        Task<string> Encrypt(string password);
        Task<bool> Compare(string password, string hash);
    }
}
