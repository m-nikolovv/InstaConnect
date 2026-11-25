using InstaConnect.Posts.Domain.Features.Posts.Models.Responses;
using InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;
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
	}

	extension(IPostCacheHandler cacheHandler)
	{
		public async Task<PostResponse?> GetByIdAsync(
			UpdatePostApiRequest request,
			CancellationToken cancellationToken)
		{
			return await cacheHandler.GetByIdAsync(request.Id, request.UserId, cancellationToken);
		}

		public async Task<PostResponse?> GetByIdAsync(
			DeletePostApiRequest request,
			CancellationToken cancellationToken)
		{
			return await cacheHandler.GetByIdAsync(request.Id, request.UserId, cancellationToken);
		}

		public async Task<PostResponse?> GetByIdAsync(
			GetPostByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			return await cacheHandler.GetByIdAsync(request.Id, request.CurrentUserId, cancellationToken);
		}
	}
}
