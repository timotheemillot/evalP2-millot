using API_Eval_P2.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace API_Eval_P2.Services.Applications
{
    public class ApplicationsService : IApplicationsService
    {
        private readonly AppDbContext _context;

        public ApplicationsService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Application>> GetApplicationsAsync()
        {
            return await _context.Applications.ToListAsync();
        }

        public async Task<Application> GetApplicationByIdAsync(int id)
        {
            return await _context.Applications.FindAsync(id);
        }

        public async Task CreateApplicationAsync(Application application)
        {
            _context.Applications.Add(application);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteApplicationAsync(int id)
        {
            var application = await _context.Applications.FindAsync(id);
            if (application == null)
            {
                throw new Exception("Application not found");
            }

            _context.Applications.Remove(application);
            await _context.SaveChangesAsync();
        }
    }
}
