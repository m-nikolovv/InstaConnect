
namespace InstaConnect.Posts.Domain.Tests.Features.Posts.Utilities;

public static class PostSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public IPostCommandService GetPostCommandService()
		{
			return serviceProvider.GetRequiredService<IPostCommandService>();
		}

		public IPostQueryService GetPostQueryService()
		{
			return serviceProvider.GetRequiredService<IPostQueryService>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public IPostCommandService GetPostCommandService()
		{
			return serviceScope.ServiceProvider.GetPostCommandService();
		}

		public IPostQueryService GetPostQueryService()
		{
			return serviceScope.ServiceProvider.GetPostQueryService();
		}

		public async Task SetupAddAsync(
			AddPostCommand command,
			Post post,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupAddAsync(post, cancellationToken);
		}

		public async Task SetupUpdateAsync(
			UpdatePostCommand command,
			Post post,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupUpdateAsync(post, command.UserId, cancellationToken);
		}

		public async Task SetupDeleteAsync(
			DeletePostCommand command,
			Post post,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupDeleteAsync(post, command.UserId, cancellationToken);
		}

		public async Task SetupGetByIdAsync(
			GetPostByIdQuery query,
			Post post,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetByIdAsync(post, cancellationToken);
		}

		public async Task SetupGetAllAsync(
			GetAllPostsQuery query,
			ICollection<Post> posts,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetAllAsync(posts, cancellationToken);
		}

		public async Task SetupGetAllForUserAsync(
			GetAllPostsForUserQuery query,
			ICollection<Post> posts,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetAllForUserAsync(posts, cancellationToken);
		}






		public async Task<PostResponse?> GetPostCacheByIdAsync(
			UpdatePostCommand command,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostCacheByIdAsync(command.Id, command.UserId, cancellationToken);
		}

		public async Task<PostResponse?> GetPostCacheByIdAsync(
			DeletePostCommand command,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostCacheByIdAsync(command.Id, command.UserId, cancellationToken);
		}

		public async Task<PostResponse?> GetPostCacheByIdAsync(
			GetPostByIdQuery query,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostCacheByIdAsync(query.Id, query.CurrentUser.Id, cancellationToken);
		}

		public async Task AddPostCacheAsync(
			UpdatePostCommand command,
			Post post,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddPostCacheAsync(post, command.UserId, cancellationToken);
		}

		public async Task AddPostCacheAsync(
			DeletePostCommand command,
			Post post,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddPostCacheAsync(post, command.UserId, cancellationToken);
		}
	}
}
