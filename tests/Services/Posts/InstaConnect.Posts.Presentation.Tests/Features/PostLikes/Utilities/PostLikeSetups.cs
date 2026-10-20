using InstaConnect.Posts.Domain.Features.PostLikes.Models.ValueObjects;
using InstaConnect.Posts.Presentation.Features.PostLikes.Controllers.v1;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Utilities;

public static class PostLikeSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public PostLikeController GetPostLikeController()
		{
			return serviceProvider.GetRequiredService<PostLikeController>();
		}

		public UserPostLikeController GetUserPostLikeController()
		{
			return serviceProvider.GetRequiredService<UserPostLikeController>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public PostLikeController GetPostLikeController()
		{
			return serviceScope.ServiceProvider.GetPostLikeController();
		}

		public UserPostLikeController GetUserPostLikeController()
		{
			return serviceScope.ServiceProvider.GetUserPostLikeController();
		}

		internal async Task<PostLike?> GetByIdAsync(
		PostLikeIdApiResponse id,
		CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				new PostLikeId(
							   new(id.Id),
							   new(id.UserId)),
				cancellationToken);
		}

		public async Task<PostLike?> GetByIdAsync(
			AddPostLikeApiResponse response,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				response.Response,
				cancellationToken);
		}

		public async Task<PostLike?> GetByIdAsync(
			ActionResult<AddPostLikeApiResponse> response,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				response.GetValue(),
				cancellationToken);
		}
	}
}
