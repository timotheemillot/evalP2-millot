using System.Security.Cryptography;
using System.Text;

namespace API_Eval_P2.Services.Encryption.Strategies
{
    public class AesEncryptionStrategy : IEncryptionStrategy
    {
        private readonly byte[] _secretKey = new byte[32] // 256 bits
        {
            0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07,
            0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F,
            0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16, 0x17,
            0x18, 0x19, 0x1A, 0x1B, 0x1C, 0x1D, 0x1E, 0x1F
        };
        private readonly byte[] _iv = new byte[16]
        {
            0xD2, 0xF7, 0xE6, 0x3C, 0x60, 0xF3, 0x34, 0x5A,
            0x42, 0x3D, 0x68, 0xB1, 0xDB, 0x0A, 0x8F, 0xA1
        };

        public string Encrypt(string data)
        {
            Console.WriteLine("Encrypting data with AES");
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = _secretKey;
                aesAlg.IV = _iv;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(data);
                        }
                    }
                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }

        public string Decrypt(string encryptedData)
        {
            Console.WriteLine("Decrypting data with AES");
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = _secretKey;
                aesAlg.IV = _iv;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(encryptedData)))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}
