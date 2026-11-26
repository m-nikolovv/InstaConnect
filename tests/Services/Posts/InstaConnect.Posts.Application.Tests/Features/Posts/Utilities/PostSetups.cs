using InstaConnect.Posts.Application.Features.Posts.Models;
using InstaConnect.Posts.Domain.Features.Posts.Models.Responses;

namespace InstaConnect.Posts.Application.Tests.Features.Posts.Utilities;

public static class PostSetups
{
	extension(IServiceScope serviceScope)
	{
		internal async Task<Post?> GetByIdAsync(
		PostIdCommandResponse id,
		CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				new PostId(id.Id),
				cancellationToken);
		}

		public async Task<Post?> GetByIdAsync(
			AddPostCommandResponse response,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				response.Response,
				cancellationToken);
		}

		public async Task<Post?> GetByIdAsync(
			UpdatePostCommandResponse response,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				response.Response,
				cancellationToken);
		}

		public async Task InitializeAddAsync(
			AddPostCommandRequest request,
			Post post,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeAddAsync(post, cancellationToken);
		}

		public async Task InitializeUpdateAsync(
			UpdatePostCommandRequest request,
			Post post,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeUpdateAsync(post, request.UserId, cancellationToken);
		}

		public async Task InitializeDeleteAsync(
			DeletePostCommandRequest request,
			Post post,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeDeleteAsync(post, request.UserId, cancellationToken);
		}

		public async Task InitializeGetByIdAsync(
			GetPostByIdQueryRequest request,
			Post post,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeGetByIdAsync(post, cancellationToken);
		}

		public async Task InitializeGetAllAsync(
			GetAllPostsQueryRequest request,
			ICollection<Post> posts,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeGetAllAsync(posts, cancellationToken);
		}

		public async Task InitializeGetAllForUserAsync(
			GetAllPostsForUserQueryRequest request,
			ICollection<Post> posts,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeGetAllForUserAsync(posts, cancellationToken);
		}

		public async Task DisposeAddAsync(
			AddPostCommandRequest request,
			Post post,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeAddAsync(post, cancellationToken);
		}

		public async Task DisposeUpdateAsync(
			UpdatePostCommandRequest request,
			Post post,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeUpdateAsync(post, cancellationToken);
		}

		public async Task DisposeDeleteAsync(
			DeletePostCommandRequest request,
			Post post,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeDeleteAsync(post, cancellationToken);
		}

		public async Task DisposeGetByIdAsync(
			GetPostByIdQueryRequest request,
			Post post,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeGetByIdAsync(post, cancellationToken);
		}

		public async Task DisposeGetAllAsync(
			GetAllPostsQueryRequest request,
			ICollection<Post> posts,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeGetAllAsync(posts, cancellationToken);
		}

		public async Task DisposeGetAllForUserAsync(
			GetAllPostsForUserQueryRequest request,
			ICollection<Post> posts,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeGetAllForUserAsync(posts, cancellationToken);
		}

		public async Task<PostResponse?> GetPostCacheByIdAsync(
			UpdatePostCommandRequest request,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostCacheByIdAsync(request.Id, request.UserId, cancellationToken);
		}

		public async Task<PostResponse?> GetPostCacheByIdAsync(
			DeletePostCommandRequest request,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostCacheByIdAsync(request.Id, request.UserId, cancellationToken);
		}

		public async Task<PostResponse?> GetPostCacheByIdAsync(
			GetPostByIdQueryRequest request,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostCacheByIdAsync(request.Id, request.CurrentUserId, cancellationToken);
		}

		public async Task AddPostCacheAsync(
			UpdatePostCommandRequest request,
			Post post,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddPostCacheAsync(post, request.UserId, cancellationToken);
		}

		public async Task AddPostCacheAsync(
			DeletePostCommandRequest request,
			Post post,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddPostCacheAsync(post, request.UserId, cancellationToken);
		}
	}
}
