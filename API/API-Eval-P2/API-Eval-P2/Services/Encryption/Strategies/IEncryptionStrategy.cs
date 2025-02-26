namespace API_Eval_P2.Services.Encryption.Strategies
{
    public interface IEncryptionStrategy
    {
        string Encrypt(string data);
        string Decrypt(string encryptedData);
    }
}
