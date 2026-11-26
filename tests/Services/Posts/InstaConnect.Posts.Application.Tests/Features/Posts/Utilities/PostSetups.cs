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

		public async Task SetupAddAsync(
			AddPostCommandRequest request,
			Post post,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupAddAsync(post, cancellationToken);
		}

		public async Task SetupUpdateAsync(
			UpdatePostCommandRequest request,
			Post post,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupUpdateAsync(post, request.UserId, cancellationToken);
		}

		public async Task SetupDeleteAsync(
			DeletePostCommandRequest request,
			Post post,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupDeleteAsync(post, request.UserId, cancellationToken);
		}

		public async Task SetupGetByIdAsync(
			GetPostByIdQueryRequest request,
			Post post,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetByIdAsync(post, cancellationToken);
		}

		public async Task SetupGetAllAsync(
			GetAllPostsQueryRequest request,
			ICollection<Post> posts,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetAllAsync(posts, cancellationToken);
		}

		public async Task SetupGetAllForUserAsync(
			GetAllPostsForUserQueryRequest request,
			ICollection<Post> posts,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetAllForUserAsync(posts, cancellationToken);
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
