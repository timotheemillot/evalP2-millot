
using API_Eval_P2.Models;
using API_Eval_P2.Services.Passwords;

namespace API_Eval_P2.Repositories
{
    public class PasswordRepository : IRepository<Password>
    {
        private readonly IPasswordsService _passwordService;

        public PasswordRepository(IPasswordsService passwordService)
        {
            _passwordService = passwordService;
        }
        public Task AddAsync(Password entity)
        {
            return _passwordService.CreatePasswordAsync(entity);

        }

        public Task DeleteAsync(int id)
        {
            return _passwordService.DeletePasswordAsync(id);
        }

        public Task<IEnumerable<Password>> GetAllAsync()
        {
            return _passwordService.GetPasswordsAsync();
        }

        public Task<Password?> GetByIdAsync(int id)
        {
            return _passwordService.GetPasswordByIdAsync(id);
        }
    }
}
