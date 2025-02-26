namespace API_Eval_P2.Services.Encryption
{
    public interface IEncryptionService
    {
        string EncryptPassword(string data, bool type);
        string DecryptPassword(string encryptedData, bool type);
    }
}
