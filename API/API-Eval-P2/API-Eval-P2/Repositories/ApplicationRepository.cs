using API_Eval_P2.Models;
using API_Eval_P2.Services.Applications;

namespace API_Eval_P2.Repositories
{
    public class ApplicationRepository : IRepository<Application>
    {
        private readonly IApplicationsService _applicationsService;

        public ApplicationRepository(IApplicationsService applicationsService)
        {
            _applicationsService = applicationsService;
        }
        public Task AddAsync(Application entity)
        {
            return _applicationsService.CreateApplicationAsync(entity);
        }

        public Task DeleteAsync(int id)
        {
            return _applicationsService.DeleteApplicationAsync(id);
        }

        public Task<IEnumerable<Application>> GetAllAsync()
        {
            return _applicationsService.GetApplicationsAsync();
        }

        public Task<Application> GetByIdAsync(int id)
        {
            return _applicationsService.GetApplicationByIdAsync(id);
        }
    }
}
