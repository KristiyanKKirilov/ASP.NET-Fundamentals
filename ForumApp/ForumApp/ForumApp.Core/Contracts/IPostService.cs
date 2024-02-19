using ForumApp.Core.Models;

namespace ForumApp.Core.Contracts
{
    public interface IPostService
    {
        Task<IEnumerable<PostModel>> GetAllPostsAsync();
        Task AddPostAsync(PostModel post);
        Task<PostModel?> GetPostByIdAsync(int id);
        Task UpdatePostAsync(PostModel post);
        Task DeletePostAsync(int id);
    }
}
