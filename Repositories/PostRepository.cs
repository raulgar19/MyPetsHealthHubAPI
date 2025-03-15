using Microsoft.EntityFrameworkCore;
using MyPetsHealthHubApi.Data;
using MyPetsHealthHubApi.Models;
using MyPetsHealthHubApi.Repositories.Interfaces;

namespace MyPetsHealthHubApi.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly AppDbContext _context;

        public PostRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddPost(Post post)
        {
            _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Post>> GetCommunityPosts(int id)
        {
            return await _context.Posts
             .Include(p => p.AppUser)
             .Where(p => p.AppUserId != id)
             .OrderByDescending(p => p.PostDate)
             .ToListAsync();
        }

        public async Task<List<Post>> GetUserPosts(int id)
        {
            return await _context.Posts
             .Where(p => p.AppUserId == id)
             .OrderByDescending(p => p.PostDate)
             .ToListAsync();
        }
    }
}