using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace API_Eval_P2.Services.Encryption.Strategies
{
    public class RsaEncryptionStrategy : IEncryptionStrategy
    {
        private RSACryptoServiceProvider rsa;

        private string publicKey;
        private string privateKey;

        private readonly string publicKeyPath = "public.key";
        private readonly string privateKeyPath = "private.key";

        public RsaEncryptionStrategy()
        {
            rsa = new RSACryptoServiceProvider(2048);  // Taille de clé RSA (2048 bits ici)

            // Vérifier si les fichiers de clés existent
            if (File.Exists(publicKeyPath) && File.Exists(privateKeyPath))
            {
                // Si les clés existent, les charger depuis les fichiers
                publicKey = File.ReadAllText(publicKeyPath);
                privateKey = File.ReadAllText(privateKeyPath);
            }
            else
            {
                // Si les clés n'existent pas, les générer
                publicKey = rsa.ToXmlString(false);  // Clé publique
                privateKey = rsa.ToXmlString(true);   // Clé privée

                // Sauvegarder les clés dans des fichiers
                File.WriteAllText(publicKeyPath, publicKey);
                File.WriteAllText(privateKeyPath, privateKey);
            }
        }

        // Méthode pour obtenir la clé publique
        public string GetPublicKey()
        {
            return publicKey;
        }

        // Méthode pour obtenir la clé privée
        public string GetPrivateKey()
        {
            return privateKey;
        }

        // Méthode pour chiffrer un message avec la clé publique
        public string Encrypt(string plainText)
        {
            rsa.FromXmlString(GetPublicKey());
            byte[] dataToEncrypt = Encoding.UTF8.GetBytes(plainText);
            byte[] encryptedData = rsa.Encrypt(dataToEncrypt, false);
            return Convert.ToBase64String(encryptedData);
        }

        // Méthode pour déchiffrer un message avec la clé privée
        public string Decrypt(string encryptedText)
        {
            rsa.FromXmlString(GetPrivateKey());
            byte[] dataToDecrypt = Convert.FromBase64String(encryptedText);
            byte[] decryptedData = rsa.Decrypt(dataToDecrypt, false);
            return Encoding.UTF8.GetString(decryptedData);
        }
    }
}
