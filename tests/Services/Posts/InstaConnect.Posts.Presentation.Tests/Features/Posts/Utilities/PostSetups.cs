using InstaConnect.Posts.Domain.Features.Posts.Models.Responses;
using InstaConnect.Posts.Presentation.Features.Posts.Controllers.v1;

namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Utilities;

public static class PostSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public PostController GetPostController()
		{
			return serviceProvider.GetRequiredService<PostController>();
		}

		public UserPostController GetUserPostController()
		{
			return serviceProvider.GetRequiredService<UserPostController>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public PostController GetPostController()
		{
			return serviceScope.ServiceProvider.GetPostController();
		}

		public UserPostController GetUserPostController()
		{
			return serviceScope.ServiceProvider.GetUserPostController();
		}

		internal async Task<Post?> GetByIdAsync(
		PostIdApiResponse id,
		CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				new PostId(id.Id),
				cancellationToken);
		}

		public async Task<Post?> GetByIdAsync(
			AddPostApiResponse response,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				response.Response,
				cancellationToken);
		}

		public async Task<Post?> GetByIdAsync(
			UpdatePostApiResponse response,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				response.Response,
				cancellationToken);
		}

		public async Task<Post?> GetByIdAsync(
			ActionResult<AddPostApiResponse> response,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				response.GetValue(),
				cancellationToken);
		}

		public async Task<Post?> GetByIdAsync(
			ActionResult<UpdatePostApiResponse> response,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				response.GetValue(),
				cancellationToken);
		}

		public async Task SetupAddAsync(
			AddPostApiRequest request,
			Post post,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupAddAsync(post, cancellationToken);
		}

		public async Task SetupUpdateAsync(
			UpdatePostApiRequest request,
			Post post,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupUpdateAsync(post, request.UserId, cancellationToken);
		}

		public async Task SetupDeleteAsync(
			DeletePostApiRequest request,
			Post post,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupDeleteAsync(post, request.UserId, cancellationToken);
		}

		public async Task SetupGetByIdAsync(
			GetPostByIdApiRequest request,
			Post post,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetByIdAsync(post, cancellationToken);
		}

		public async Task SetupGetAllAsync(
			GetAllPostsApiRequest request,
			ICollection<Post> posts,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetAllAsync(posts, cancellationToken);
		}

		public async Task SetupGetAllForUserAsync(
			GetAllPostsForUserApiRequest request,
			ICollection<Post> posts,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetAllForUserAsync(posts, cancellationToken);
		}






		public async Task<PostResponse?> GetPostCacheByIdAsync(
			UpdatePostApiRequest request,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostCacheByIdAsync(request.Id, request.UserId, cancellationToken);
		}

		public async Task<PostResponse?> GetPostCacheByIdAsync(
			DeletePostApiRequest request,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostCacheByIdAsync(request.Id, request.UserId, cancellationToken);
		}

		public async Task<PostResponse?> GetPostCacheByIdAsync(
			GetPostByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostCacheByIdAsync(request.Id, request.CurrentUserId, cancellationToken);
		}

		public async Task AddPostCacheAsync(
			UpdatePostApiRequest request,
			Post post,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddPostCacheAsync(post, request.UserId, cancellationToken);
		}

		public async Task AddPostCacheAsync(
			DeletePostApiRequest request,
			Post post,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddPostCacheAsync(post, request.UserId, cancellationToken);
		}
	}
}
