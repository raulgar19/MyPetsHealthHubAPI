using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPetsHealthHubApi.Models;
using MyPetsHealthHubApi.Models.RequestModels;
using MyPetsHealthHubApi.Services.Interfaces;

namespace MyPetsHealthHubApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpPost("addPost")]
        public async Task<ActionResult> AddPost([FromBody] RegisterPostModel registerPostModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Post post = new Post
            {
                Description = registerPostModel.Description,
                Image = registerPostModel.ImageUrl,
                PostDate = DateTime.Now,
                AppUserId = registerPostModel.UserId
            };

            try
            {
                await _postService.AddPost(post);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding post: {ex.Message}");
            }

            return Ok();
        }

        [HttpGet("getUserPosts/{id}")]
        public async Task<ActionResult<List<Post>>> GetUserPosts(int id)
        {
            List<Post> posts = await _postService.GetUserPosts(id);

            if (posts == null || posts.Count == 0)
            {
                return NotFound("No se han encontrado posts para ese usuario");
            }

            return Ok(posts);
        }

        [HttpGet("getCommunityPosts/{id}")]
        public async Task<ActionResult<List<Post>>> GetCommunityPosts(int id)
        {
            List<Post> posts = await _postService.GetCommunityPosts(id);

            if (posts == null || posts.Count == 0)
            {
                return NotFound("No se han encontrado posts");
            }

            return Ok(posts);
        }
    }
}