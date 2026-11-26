
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

		public async Task InitializeAddAsync(
			AddPostCommand command,
			Post post,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeAddAsync(post, cancellationToken);
		}

		public async Task InitializeUpdateAsync(
			UpdatePostCommand command,
			Post post,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeUpdateAsync(post, command.UserId, cancellationToken);
		}

		public async Task InitializeDeleteAsync(
			DeletePostCommand command,
			Post post,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeDeleteAsync(post, command.UserId, cancellationToken);
		}

		public async Task InitializeGetByIdAsync(
			GetPostByIdQuery query,
			Post post,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeGetByIdAsync(post, cancellationToken);
		}

		public async Task InitializeGetAllAsync(
			GetAllPostsQuery query,
			ICollection<Post> posts,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeGetAllAsync(posts, cancellationToken);
		}

		public async Task InitializeGetAllForUserAsync(
			GetAllPostsForUserQuery query,
			ICollection<Post> posts,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeGetAllForUserAsync(posts, cancellationToken);
		}

		public async Task DisposeAddAsync(
			AddPostCommand command,
			Post post,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeAddAsync(post, cancellationToken);
		}

		public async Task DisposeUpdateAsync(
			UpdatePostCommand command,
			Post post,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeUpdateAsync(post, cancellationToken);
		}

		public async Task DisposeDeleteAsync(
			DeletePostCommand command,
			Post post,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeDeleteAsync(post, cancellationToken);
		}

		public async Task DisposeGetByIdAsync(
			GetPostByIdQuery query,
			Post post,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeGetByIdAsync(post, cancellationToken);
		}

		public async Task DisposeGetAllAsync(
			GetAllPostsQuery query,
			ICollection<Post> posts,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeGetAllAsync(posts, cancellationToken);
		}

		public async Task DisposeGetAllForUserAsync(
			GetAllPostsForUserQuery query,
			ICollection<Post> posts,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeGetAllForUserAsync(posts, cancellationToken);
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
