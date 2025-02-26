using API_Eval_P2.Models;
using API_Eval_P2.NewFolder;
using API_Eval_P2.Repositories;
using API_Eval_P2.Services.Passwords;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Eval_P2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PasswordsController : ControllerBase
    {
        private readonly IRepository<Password> _passwordRepository;
        private readonly IRepository<Application> _applicationRepository;

        public PasswordsController(IRepository<Password> passwordRepository, IRepository<Application> applicationRepository)
        {
            _passwordRepository = passwordRepository;
            _applicationRepository = applicationRepository;
        }

        [ApiKey]
        [HttpGet]
        public async Task<IEnumerable<Password>> GetAll()
        {
            return await _passwordRepository.GetAllAsync();
        }
        [ApiKey]
        [HttpGet("{id}")]
        public async Task<Password?> GetById(int id)
        {
            return await _passwordRepository.GetByIdAsync(id);
        }
        [ApiKey]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Password password)
        {
           
            var application = await _applicationRepository.GetByIdAsync(password.Application.Id);

            if (application == null)
            {
                return BadRequest("Invalid Application ID.");
            }
            password.Application = application;

            await _passwordRepository.AddAsync(password);

            return StatusCode(StatusCodes.Status201Created);
        }
        [ApiKey]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _passwordRepository.DeleteAsync(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }


    }

}
