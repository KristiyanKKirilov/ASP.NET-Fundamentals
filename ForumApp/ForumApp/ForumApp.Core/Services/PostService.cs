using ForumApp.Core.Contracts;
using ForumApp.Core.Models;
using ForumApp.Infrastructure.Data;
using ForumApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ForumApp.Core.Services
{
	public class PostService : IPostService
	{
		private readonly ForumDbContext context;
		private readonly ILogger logger;

		public PostService(
			ForumDbContext _context,
			ILogger<PostService> _logger)
		{
			context = _context;
			logger = _logger;
		}


        public async Task<IEnumerable<PostModel>> GetAllPostsAsync()
		{
			var posts = await context.Posts
				.AsNoTracking()
				.Select(p => new PostModel()
				{
					Id = p.Id,
					Title = p.Title,
					Content = p.Content,
				}).ToListAsync();

			return posts;
		}
        public async Task AddPostAsync(PostModel post)
        {
			Post postToAdd = new Post()
			{				
				Title = post.Title,
				Content = post.Content,
			};

			try
			{
                await context.Posts.AddAsync(postToAdd);
                await context.SaveChangesAsync();
            }
			catch (Exception ex) 
			{

				logger.LogError(ex, "PostService.AddPostAsync");

				throw new ApplicationException("Operation failed. Please, try again!");
			}
			
        }

		public async Task<PostModel?> GetPostByIdAsync(int id)
		{
			return await context.Posts
				.Where(p => p.Id == id)
				.Select(p => new PostModel()
				{
					Id = p.Id,
					Title = p.Title,
					Content = p.Content,
				})
				.AsNoTracking()
				.FirstOrDefaultAsync();

		}

		public async Task UpdatePostAsync(PostModel model)
		{
            var entity = await GetByIdAsync(model.Id);

            entity.Title = model.Title;
			entity.Content = model.Content;

			await context.SaveChangesAsync();

		}

		public async Task DeletePostAsync(int id)
		{
            var entity = await GetByIdAsync(id);

			context.Posts.Remove(entity);
			await context.SaveChangesAsync();
        }

		private async Task<Post> GetByIdAsync(int id)
		{
            var entity = await context.FindAsync<Post>(id);

            if (entity == null)
            {
                throw new ApplicationException("Invalid post");
            }

			return entity;
        }
	}
}
