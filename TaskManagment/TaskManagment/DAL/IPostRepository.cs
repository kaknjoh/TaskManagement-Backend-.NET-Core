using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagment.Models;

namespace TaskManagment.DAL
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> getAllPostsAsync();

        Task SavePost(Post post);

        Task<Post> GetPostByIdAsync(int id);

        Task EditPostAsync(Post post);

        Task DeletePostAsync(Post post);
    }
}
