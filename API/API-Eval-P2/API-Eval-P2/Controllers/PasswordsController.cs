using API_Eval_P2.Models;
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

        public PasswordsController(IRepository<Password> passwordRepository)
        {
            _passwordRepository = passwordRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Password>> GetAll()
        {
            return await _passwordRepository.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<Password?> GetById(int id)
        {
            return await _passwordRepository.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Password password)
        {
            await _passwordRepository.AddAsync(password);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _passwordRepository.DeleteAsync(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }


    }

}
