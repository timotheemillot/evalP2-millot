using API_Eval_P2.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Eval_P2.Services.Passwords
{
    public class PasswordsService : IPasswordsService
    {
        private readonly AppDbContext _context;

        public PasswordsService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Password>> GetPasswordsAsync()
        {
            return await this._context.Passwords.ToListAsync();
        }

        public async Task<Password> GetPasswordByIdAsync(int id)
        {
            return await this._context.Passwords
                                      .Include(p => p.Application) 
                                      .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task CreatePasswordAsync(Password application)
        {
            this._context.Passwords.Add(application);
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
