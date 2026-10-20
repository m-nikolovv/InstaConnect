using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.ValueObjects;
using InstaConnect.Posts.Presentation.Features.PostCommentLikes.Controllers.v1;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public PostCommentLikeController GetPostCommentLikeController()
		{
			return serviceProvider.GetRequiredService<PostCommentLikeController>();
		}

		public UserPostCommentLikeController GetUserPostCommentLikeController()
		{
			return serviceProvider.GetRequiredService<UserPostCommentLikeController>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public PostCommentLikeController GetPostCommentLikeController()
		{
			return serviceScope.ServiceProvider.GetPostCommentLikeController();
		}

		public UserPostCommentLikeController GetUserPostCommentLikeController()
		{
			return serviceScope.ServiceProvider.GetUserPostCommentLikeController();
		}

		internal async Task<PostCommentLike?> GetByIdAsync(
		PostCommentLikeIdApiResponse id,
		CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				new PostCommentLikeId(
									  new(
										  new(id.Id),
										  id.CommentId),
									  new(id.UserId)),
				cancellationToken);
		}

		public async Task<PostCommentLike?> GetByIdAsync(
			AddPostCommentLikeApiResponse response,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				response.Response,
				cancellationToken);
		}

		public async Task<PostCommentLike?> GetByIdAsync(
			ActionResult<AddPostCommentLikeApiResponse> response,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				response.GetValue(),
				cancellationToken);
		}
	}
}
