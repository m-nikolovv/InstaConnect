using InstaConnect.Posts.Presentation.Features.Posts.Controllers.v1;

using Microsoft.Extensions.DependencyInjection;

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
}
