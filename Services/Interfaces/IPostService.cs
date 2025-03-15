using MyPetsHealthHubApi.Models;

namespace MyPetsHealthHubApi.Services.Interfaces
{
    public interface IPostService
    {
        Task AddPost(Post post);
        Task<List<Post>> GetUserPosts(int id);
    }
}