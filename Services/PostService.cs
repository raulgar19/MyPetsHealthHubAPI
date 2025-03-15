using MyPetsHealthHubApi.Models;
using MyPetsHealthHubApi.Repositories.Interfaces;
using MyPetsHealthHubApi.Services.Interfaces;

namespace MyPetsHealthHubApi.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task AddPost(Post post)
        {
            await _postRepository.AddPost(post);
        }

        public async Task<List<Post>> GetCommunityPosts(int id)
        {
            return await _postRepository.GetCommunityPosts(id);
        }

        public async Task<List<Post>> GetUserPosts(int id)
        {
            return await _postRepository.GetUserPosts(id);
        }
    }
}