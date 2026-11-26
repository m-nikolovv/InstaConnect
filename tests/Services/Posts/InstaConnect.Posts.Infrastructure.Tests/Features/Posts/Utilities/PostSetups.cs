using InstaConnect.Posts.Domain.Features.Posts.Models.Responses;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Infrastructure.Tests.Features.Posts.Utilities;

public static class PostSetups
{
	extension(IServiceScope serviceScope)
	{
		public async Task<PostResponse?> GetPostCacheByIdAsync(
			PostId id,
			CurrentUserQuery currentUserQuery,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostCacheByIdAsync(id, currentUserQuery.Id, cancellationToken);
		}

		public async Task<PostResponse?> GetPostCacheByIdAsync(
			Post post,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostCacheByIdAsync(post, post.UserId, cancellationToken);
		}

		public async Task SetupUpdateAsync(
			Post post,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupUpdateAsync(post, post.UserId, cancellationToken);
		}

		public async Task SetupDeleteAsync(
			Post post,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupDeleteAsync(post, post.UserId, cancellationToken);
		}
	}

}
