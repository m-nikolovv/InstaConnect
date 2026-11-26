using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Responses;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.ValueObjects;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Responses;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Infrastructure.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeSetups
{
	extension(IServiceScope serviceScope)
	{
		public async Task<PostCommentLikeResponse?> GetPostCommentLikeCacheByIdAsync(
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostCommentLikeCacheByIdAsync(postCommentLike.Id, postCommentLike.Id.UserId, cancellationToken);
		}

		public async Task<PostCommentLikeResponse?> GetPostCommentLikeCacheByIdAsync(
			PostCommentLikeId id,
			CurrentUserQuery currentUserQuery,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostCommentLikeCacheByIdAsync(id, currentUserQuery.Id, cancellationToken);
		}

		public async Task<PostCommentResponse?> GetPostCommentCacheByIdAsync(
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostCommentCacheByIdAsync(postCommentLike.Id.CommentId, postCommentLike.Id.UserId, cancellationToken);
		}

		public async Task SetupAddAsync(
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupAddAsync(postCommentLike, postCommentLike.Id.UserId, cancellationToken);
		}

		public async Task SetupDeleteAsync(
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupDeleteAsync(postCommentLike, postCommentLike.Id.UserId, cancellationToken);
		}
	}

}
