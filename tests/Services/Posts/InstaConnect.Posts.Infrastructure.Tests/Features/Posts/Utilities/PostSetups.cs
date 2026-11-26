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

		public async Task SetupUpdatePostAsync(
			User user,
			Post post,
			ICollection<PostImage> postImages,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupUpdatePostAsync(user, post, postImages, post.UserId, cancellationToken);
		}

		public async Task SetupDeletePostAsync(
			ICollection<User> users,
			Post post,
			ICollection<PostLike> postLikes,
			ICollection<PostImage> postImages,
			ICollection<PostComment> postComments,
			ICollection<PostCommentLike> postCommentLikes,
			ICollection<PostCommentImage> postCommentImages,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupDeletePostAsync(users, post, postLikes, postImages, postComments, postCommentLikes, postCommentImages, post.UserId, cancellationToken);
		}
	}

}
