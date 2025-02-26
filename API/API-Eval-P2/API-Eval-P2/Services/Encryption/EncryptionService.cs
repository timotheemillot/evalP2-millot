using API_Eval_P2.Models;
using API_Eval_P2.Services.Encryption.Strategies;
using static System.Net.Mime.MediaTypeNames;

namespace API_Eval_P2.Services.Encryption
{
    public class EncryptionService : IEncryptionService
    {
        private IEncryptionStrategy _encryptionStrategy;

        public string EncryptPassword(string password, bool type)
        {
            _encryptionStrategy = type ? new AesEncryptionStrategy() : new RsaEncryptionStrategy();
            return _encryptionStrategy.Encrypt(password);
        }

        public string DecryptPassword(string encryptedPassword, bool type)
        {
            _encryptionStrategy = type ? new AesEncryptionStrategy() : new RsaEncryptionStrategy();
            return _encryptionStrategy.Decrypt(encryptedPassword);
        }

    }
}
