using MyPetsHealthHubApi.Models;

namespace MyPetsHealthHubApi.Repositories.Interfaces
{
    public interface IPostRepository
    {
        Task AddPost(Post post);
        Task DeleteUserPosts(List<Post> posts);
        Task<List<Post>> GetCommunityPosts(int id);
        Task<List<Post>> GetUserPosts(int id);
    }
}