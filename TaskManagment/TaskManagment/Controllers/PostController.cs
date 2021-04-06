using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TaskManagment.Domain;
using TaskManagment.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskManagment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly ILogger<PostController> _logger;
        public PostController(IPostService postService, ILogger<PostController> logger)
        {
            _postService = postService;
            _logger = logger;
        }



        // GET: api/Posts
       
        [HttpGet]
        public async Task<IActionResult>GetAllPosts()
        {
            return Ok(await _postService.GetAllPostsAsync());
        }

        // GET api/Post/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPostById(int id)
        {
            Post postInDb = await _postService.GetPostByIdAsync(id);
            if (postInDb == null)
            {
                return NotFound();
            }

            return  Ok(await _postService.GetPostByIdAsync(id));
        }

        // POST api/Post
        [HttpPost]
        public async Task<IActionResult> SavePost(Post post)
        {
            await _postService.SavePostAsync(post);
            return CreatedAtAction(nameof(GetPostById), new { id = post.PostId }, post);
        }

        // PUT api/Post/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Post post)
        {
            Post postInDb = await _postService.GetPostByIdAsync(id);
            if (postInDb == null)
            {
                return NotFound();
            }
            await _postService.EditPostAsync(postInDb, post);
            return Ok();

        }

        // DELETE api/Post/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Post postInDb =await _postService.GetPostByIdAsync(id);
            if(postInDb == null)
            {
                return NotFound();
            }
            await _postService.DeletePostAsync(postInDb);
            return Ok();
        }
    }
}
