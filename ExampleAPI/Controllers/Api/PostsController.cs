using ExampleAPI.Models;
using ExampleAPI.Models.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExampleAPI.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostRepository _postRepository;

        public PostsController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var posts = _postRepository.AllPosts;
            return Ok(posts);
        }

        [HttpPost]
        public IActionResult AddPost([FromBody] Post post)
        {
            _postRepository.AddPost(post);
            return Ok();
        }
    }
}
