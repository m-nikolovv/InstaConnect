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

		public async Task SetupAddPostLikeAsync(
			User user,
			Post post,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupAddPostLikeAsync(user, post, user.Id, cancellationToken);
		}

		public async Task SetupDeletePostLikeAsync(
			User user,
			Post post,
			PostLike postLike,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupDeletePostLikeAsync(user, post, postLike, postLike.Id.UserId, cancellationToken);
		}
	}

}
