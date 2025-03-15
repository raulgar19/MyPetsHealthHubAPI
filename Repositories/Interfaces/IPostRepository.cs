using MyPetsHealthHubApi.Models;

namespace MyPetsHealthHubApi.Repositories.Interfaces
{
    public interface IPostRepository
    {
        Task AddPost(Post post);
        Task<List<Post>> GetUserPosts(int id);
    }
}