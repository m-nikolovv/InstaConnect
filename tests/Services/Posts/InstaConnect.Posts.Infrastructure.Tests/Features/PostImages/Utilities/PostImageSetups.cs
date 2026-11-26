using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Infrastructure.Tests.Features.PostImages.Utilities;

public static class PostImageSetups
{
	extension(IServiceScope serviceScope)
	{
		public async Task SetupAddPostImageAsync(
			User user,
			Post post,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupAddPostImageAsync(user, post, post.UserId, cancellationToken);
		}

		public async Task SetupDeletePostImageAsync(
			User user,
			Post post,
			PostImage postImage,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupDeletePostImageAsync(user, post, postImage, post.UserId, cancellationToken);
		}
	}
}
