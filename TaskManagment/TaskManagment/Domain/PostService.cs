using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagment.DAL;
using TaskManagment.Models;

namespace TaskManagment.Domain
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            this._postRepository = postRepository;
        }

        public async Task DeletePostAsync(Post post)
        {
            await _postRepository.DeletePostAsync(post);
        }

        public async Task EditPostAsync(Post postInDb, Post editPost)
        {
            postInDb.Name = editPost.Name;
            postInDb.Description = editPost.Description;
            postInDb.StartDate = editPost.StartDate;
            postInDb.EndDate = editPost.EndDate;
              await _postRepository.EditPostAsync(postInDb);
        }

        public Task<IEnumerable<Post>> GetAllPostsAsync()
        {
            return _postRepository.getAllPostsAsync();
        }

        public  async Task<Post> GetPostByIdAsync(int id)
        {
            return await _postRepository.GetPostByIdAsync(id);
        }

        public  async Task SavePostAsync(Post post)
        {
             await _postRepository.SavePost(post);
        }
    }
       
    
}
