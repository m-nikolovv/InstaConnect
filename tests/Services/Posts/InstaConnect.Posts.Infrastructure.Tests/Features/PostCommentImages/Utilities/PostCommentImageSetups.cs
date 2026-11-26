using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Infrastructure.Tests.Features.PostCommentImages.Utilities;

public static class PostCommentImageSetups
{
	extension(IServiceScope serviceScope)
	{
		public async Task SetupAddPostCommentImageAsync(
			User user,
			Post post,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupAddPostCommentImageAsync(user, post, postComment, postComment.UserId, cancellationToken);
		}

		public async Task SetupDeletePostCommentImageAsync(
			User user,
			Post post,
			PostComment postComment,
			PostCommentImage postCommentImage,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupDeletePostCommentImageAsync(user, post, postComment, postCommentImage, postComment.UserId, cancellationToken);
		}
	}
}
