using API_Eval_P2.Models;
using API_Eval_P2.Services.Encryption;
using Microsoft.EntityFrameworkCore;

namespace API_Eval_P2.Services.Passwords
{
    public class PasswordsService : IPasswordsService
    {
        private readonly AppDbContext _context;
        private readonly IEncryptionService _encryptionService;

        public PasswordsService(AppDbContext context, IEncryptionService encryptionService)
        {
            _context = context;
            _encryptionService = encryptionService;
        }

        public async Task<IEnumerable<Password>> GetPasswordsAsync()
        {
            return await this._context.Passwords.ToListAsync();
        }

        public async Task<Password> GetPasswordByIdAsync(int id)
        {
            Password password = await this._context.Passwords
                                      .Include(p => p.Application)
                                      .FirstOrDefaultAsync(p => p.Id == id);

            Console.WriteLine("iebvfhuezgyufihez " + password.Content);

            password.Content = this._encryptionService.DecryptPassword(password.Content, password.Application.Type);

            return password;
        }

        public async Task CreatePasswordAsync(Password password)
        {
            password.Content = this._encryptionService.EncryptPassword(password.Content, password.Application.Type);

            this._context.Passwords.Add(password);
            await this._context.SaveChangesAsync();
        }

        public async Task DeletePasswordAsync(int id)
        {
            var password = await this._context.Passwords.FindAsync(id);
            if (password == null)
            {
                throw new Exception("Password not found");
            }

            this._context.Passwords.Remove(password);
            await this._context.SaveChangesAsync();
        }
    }
}
