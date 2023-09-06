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
        
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var post = _postRepository.GetPostById(id);
            return Ok(post);
        }

        [HttpPost("json"), FormatFilter]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult AddPostJson([FromBody] Post post)
        {
            _postRepository.AddPost(post);
            return Ok(post);
        }
        
        [HttpPost("xml")]
        [Consumes("application/xml")]
        [Produces("application/xml")]
        public IActionResult AddPostXml([FromBody] Post post)
        {
            _postRepository.AddPost(post);
            return Ok(post);
        }
        
    }
}
