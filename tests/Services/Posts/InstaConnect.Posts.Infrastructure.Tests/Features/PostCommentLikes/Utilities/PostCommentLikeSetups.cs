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

		public async Task SetupAddPostCommentLikeAsync(
			User user,
			Post post,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupAddPostCommentLikeAsync(user, post, postComment, user.Id, cancellationToken);
		}

		public async Task SetupDeletePostCommentLikeAsync(
			User user,
			Post post,
			PostComment postComment,
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupDeletePostCommentLikeAsync(user, post, postComment, postCommentLike, postCommentLike.Id.UserId, cancellationToken);
		}
	}

}
