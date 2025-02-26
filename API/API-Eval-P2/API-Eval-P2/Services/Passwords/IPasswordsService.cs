using API_Eval_P2.Models;

namespace API_Eval_P2.Services.Passwords
{
    public interface IPasswordsService
    {
        Task<IEnumerable<Password>> GetPasswordsAsync();
        Task<Password> GetPasswordByIdAsync(int id);
        Task CreatePasswordAsync(Password application);

        Task DeletePasswordAsync(int id);
    }
}
