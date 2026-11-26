using InstaConnect.Posts.Domain.Features.PostComments.Models.Responses;
using InstaConnect.Posts.Domain.Features.Posts.Models.Responses;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Infrastructure.Tests.Features.PostComments.Utilities;

public static class PostCommentSetups
{
	extension(IServiceScope serviceScope)
	{
		public async Task<PostCommentResponse?> GetPostCommentCacheByIdAsync(
			PostCommentId id,
			CurrentUserQuery currentUserQuery,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostCommentCacheByIdAsync(id, currentUserQuery.Id, cancellationToken);
		}

		public async Task<PostCommentResponse?> GetPostCommentCacheByIdAsync(
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostCommentCacheByIdAsync(postComment, postComment.UserId, cancellationToken);
		}

		public async Task<PostResponse?> GetPostCacheByIdAsync(
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostCacheByIdAsync(postComment, postComment.UserId, cancellationToken);
		}

		public async Task SetupAddPostCommentAsync(
			User user,
			Post post,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupAddPostCommentAsync(user, post, user.Id, cancellationToken);
		}

		public async Task SetupUpdatePostCommentAsync(
			User user,
			Post post,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupUpdatePostCommentAsync(user, post, postComment, postComment.UserId, cancellationToken);
		}

		public async Task SetupDeletePostCommentAsync(
			ICollection<User> users,
			Post post,
			PostComment postComment,
			ICollection<PostCommentLike> postCommentLikes,
			ICollection<PostCommentImage> postCommentImages,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupDeletePostCommentAsync(users, post, postComment, postCommentLikes, postCommentImages, postComment.UserId, cancellationToken);
		}
	}
}
