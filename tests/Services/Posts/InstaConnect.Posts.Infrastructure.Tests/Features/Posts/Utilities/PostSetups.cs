using InstaConnect.Posts.Domain.Features.Posts.Models.Responses;
using InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Tests.Features.Posts.Utilities;

public static class PostSetups
{
	extension(IPostCacheHandler cacheHandler)
	{
		public async Task<PostResponse?> GetByIdAsync(
			Post post,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			return await cacheHandler.GetByIdAsync(post.Id, currentUserId, cancellationToken);
		}

		public async Task<PostResponse?> GetByIdAsync(
			PostId id,
			CurrentUserQuery currentUserQuery,
			CancellationToken cancellationToken)
		{
			return await cacheHandler.GetByIdAsync(id, currentUserQuery.Id, cancellationToken);
		}
	}
}
