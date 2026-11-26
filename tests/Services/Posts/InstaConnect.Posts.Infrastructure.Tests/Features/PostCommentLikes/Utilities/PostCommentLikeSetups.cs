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
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostCommentLikeCacheByIdAsync(postCommentLike.Id, currentUserId, cancellationToken);
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
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostCommentCacheByIdAsync(postCommentLike.Id.CommentId, currentUserId, cancellationToken);
		}
	}

}
