using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExampleAPI.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        public IActionResult GetAll()
        {
            return Ok("test");
        }
    }
}
