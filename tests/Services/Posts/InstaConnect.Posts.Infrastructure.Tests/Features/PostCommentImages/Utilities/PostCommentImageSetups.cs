using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Infrastructure.Tests.Features.PostCommentImages.Utilities;

public static class PostCommentImageSetups
{
	extension(IServiceScope serviceScope)
	{
		public async Task SetupAddAsync(
			PostCommentImage postCommentImage,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupAddAsync(postCommentImage, postCommentImage.PostComment!.UserId, cancellationToken);
		}

		public async Task SetupDeleteAsync(
			PostCommentImage postCommentImage,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupDeleteAsync(postCommentImage, postCommentImage.PostComment!.UserId, cancellationToken);
		}
	}
}
