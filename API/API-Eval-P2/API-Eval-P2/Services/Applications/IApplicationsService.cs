

using API_Eval_P2.Models;

namespace API_Eval_P2.Services.Applications
{
    public interface IApplicationsService
    {
        Task<IEnumerable<Application>> GetApplicationsAsync();
        Task<Application> GetApplicationByIdAsync(int id);
        Task CreateApplicationAsync(Application application);

        Task DeleteApplicationAsync(int id);

    }
}
