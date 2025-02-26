using API_Eval_P2.Models;
using API_Eval_P2.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API_Eval_P2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicationsController : ControllerBase
    {
        private readonly IRepository<Application> _applicationRepository;

        public ApplicationsController(IRepository<Application> applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }

        [HttpGet]

        public async Task<IEnumerable<Application>> GetAll()
        {
            return await _applicationRepository.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<Application?> GetById(int id)
        {
            return await _applicationRepository.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Application application)
        {
            await _applicationRepository.AddAsync(application);
            return StatusCode(StatusCodes.Status201Created);
        }


    }
}
