using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagment.AppData;
using TaskManagment.Models;

namespace TaskManagment.DAL
{
    public class PostRepository : IPostRepository
    {

        PostDbContext _context;
       public PostRepository(PostDbContext context)
        {
            _context = context;
        }

        public async Task DeletePostAsync(Post post)
        {
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
        }

        public async Task EditPostAsync(Post post)
        {
            _context.Posts.Update(post);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Post>> getAllPostsAsync()
        {
            return await _context.Posts.ToListAsync();
        }

        public async Task<Post> GetPostByIdAsync(int id)
        {
            return await _context.Posts.SingleOrDefaultAsync(c => c.PostId == id);
        }

        public async Task SavePost(Post post)
        {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();

        }


        
    }
}
