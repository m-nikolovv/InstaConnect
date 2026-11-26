using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Infrastructure.Tests.Features.PostImages.Utilities;

public static class PostImageSetups
{
	extension(IServiceScope serviceScope)
	{
		public async Task SetupAddAsync(
			PostImage postImage,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupAddAsync(postImage, postImage.Post!.UserId, cancellationToken);
		}

		public async Task SetupDeleteAsync(
			PostImage postImage,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupDeleteAsync(postImage, postImage.Post!.UserId, cancellationToken);
		}
	}
}
