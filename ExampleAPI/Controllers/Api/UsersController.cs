using ExampleAPI.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ExampleAPI.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _userRepository.GetAll;
            return Ok(users);
        }

        [HttpGet("id={id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _userRepository.GetById(id);
            if(user is null)
            {
                return NoContent();
            }
            return Ok(user);
        }

        [HttpGet("name={name}")]
        public IActionResult GetUsersByName(string name)
        {
            var users = _userRepository.GetByName(name);
            if(users is null || !users.Any())
            {
                return NoContent();
            }
            return Ok(users);
        }
    }
}
