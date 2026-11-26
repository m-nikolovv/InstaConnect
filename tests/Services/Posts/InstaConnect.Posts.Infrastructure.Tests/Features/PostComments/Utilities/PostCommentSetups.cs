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

		public async Task SetupAddAsync(
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupAddAsync(postComment, postComment.UserId, cancellationToken);
		}

		public async Task SetupUpdateAsync(
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupUpdateAsync(postComment, postComment.UserId, cancellationToken);
		}

		public async Task SetupDeleteAsync(
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupDeleteAsync(postComment, postComment.UserId, cancellationToken);
		}
	}
}
