using CryptSharp;
using System.Text;

namespace FJU.Inventario.Application.Common.EncriptedPassword
{
    public class EncryptionPassword : IEncryptionPassword
    {
        public Task<string> Encrypt(string password)
        {
                return Task.FromResult(Crypter.MD5.Crypt(password));
        }

        public Task<bool> Compare(string password, string hash)
        {
            return Task.FromResult(Crypter.CheckPassword(password, hash));
        }
    }
}
