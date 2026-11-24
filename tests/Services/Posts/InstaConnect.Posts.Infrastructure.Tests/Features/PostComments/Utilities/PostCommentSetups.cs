using InstaConnect.Posts.Domain.Features.PostComments.Models.Responses;
using InstaConnect.Posts.Domain.Features.Posts.Models.Responses;
using InstaConnect.Posts.Infrastructure.Features.PostComments.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Tests.Features.PostComments.Utilities;

public static class PostCommentSetups
{
	extension(IPostCommentCacheHandler cacheHandler)
	{
		public async Task<PostCommentResponse?> GetByIdAsync(
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			return await cacheHandler.GetByIdAsync(postComment.Id, postComment.UserId, cancellationToken);
		}

		public async Task<PostCommentResponse?> GetByIdAsync(
			PostCommentId id,
			CurrentUserQuery currentUserQuery,
			CancellationToken cancellationToken)
		{
			return await cacheHandler.GetByIdAsync(id, currentUserQuery.Id, cancellationToken);
		}
	}

	extension(IPostCacheHandler cacheHandler)
	{
		public async Task<PostResponse?> GetByIdAsync(
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			return await cacheHandler.GetByIdAsync(postComment.Id.Id, postComment.UserId, cancellationToken);
		}
	}
}
