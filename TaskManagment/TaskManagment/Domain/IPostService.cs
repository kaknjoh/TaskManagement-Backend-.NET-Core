using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagment.Models;

namespace TaskManagment.Domain
{
    public interface IPostService
    {

        public  Task<IEnumerable<Post>> GetAllPostsAsync();
        public Task SavePostAsync(Post post);

        public Task<Post> GetPostByIdAsync(int id);

        public Task EditPostAsync(Post postInDb , Post editPost );

        public Task DeletePostAsync(Post post);

    }
}
