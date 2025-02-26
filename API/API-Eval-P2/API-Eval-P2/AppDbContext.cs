using Microsoft.EntityFrameworkCore;

namespace API_Eval_P2
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Models.Password> Passwords { get; set; }
        public DbSet<Models.Application> Applications { get; set; }
    }
}
