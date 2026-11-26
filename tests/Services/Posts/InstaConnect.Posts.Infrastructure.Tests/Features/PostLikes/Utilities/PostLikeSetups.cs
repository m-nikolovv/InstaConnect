using InstaConnect.Posts.Domain.Features.PostLikes.Models.Responses;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.ValueObjects;
using InstaConnect.Posts.Domain.Features.Posts.Models.Responses;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Infrastructure.Tests.Features.PostLikes.Utilities;

public static class PostLikeSetups
{
	extension(IServiceScope serviceScope)
	{
		public async Task<PostLikeResponse?> GetPostLikeCacheByIdAsync(
			PostLike postLike,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostLikeCacheByIdAsync(postLike.Id, postLike.Id.UserId, cancellationToken);
		}

		public async Task<PostLikeResponse?> GetPostLikeCacheByIdAsync(
			PostLikeId id,
			CurrentUserQuery currentUserQuery,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostLikeCacheByIdAsync(id, currentUserQuery.Id, cancellationToken);
		}

		public async Task<PostResponse?> GetPostCacheByIdAsync(
			PostLike postLike,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostCacheByIdAsync(postLike.Id.Id, postLike.Id.UserId, cancellationToken);
		}

		public async Task SetupAddAsync(
			PostLike postLike,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupAddAsync(postLike, postLike.Id.UserId, cancellationToken);
		}

		public async Task SetupDeleteAsync(
			PostLike postLike,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupDeleteAsync(postLike, postLike.Id.UserId, cancellationToken);
		}
	}

}
