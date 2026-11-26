using InstaConnect.Posts.Application.Features.PostCommentLikes.Models;
using InstaConnect.Posts.Domain.Features.PostCommentImages.Models.Entities;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Responses;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.ValueObjects;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Responses;
using InstaConnect.Posts.Domain.Features.PostImages.Models.Entities;

namespace InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeSetups
{
	extension(IServiceScope serviceScope)
	{
		internal async Task<PostCommentLike?> GetByIdAsync(
			PostCommentLikeIdCommandResponse id,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				new PostCommentLikeId(
					new(
						new(id.Id),
						id.CommentId),
					new(id.UserId)),
				cancellationToken);
		}

		public async Task<PostCommentLike?> GetByIdAsync(
			AddPostCommentLikeCommandResponse response,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				response.Response,
				cancellationToken);
		}

		public async Task<PostCommentLikeResponse?> GetPostCommentLikeCacheByIdAsync(
			DeletePostCommentLikeCommandRequest request,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostCommentLikeCacheByIdAsync(request.Id, request.CommentId, request.UserId, request.UserId, cancellationToken);
		}

		public async Task<PostCommentLikeResponse?> GetPostCommentLikeCacheByIdAsync(
			GetPostCommentLikeByIdQueryRequest request,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostCommentLikeCacheByIdAsync(request.Id, request.CommentId, request.UserId, request.CurrentUserId, cancellationToken);
		}

		public async Task<PostCommentResponse?> GetPostCommentCacheByIdAsync(
			AddPostCommentLikeCommandRequest request,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostCommentCacheByIdAsync(request.Id, request.CommentId, request.UserId, cancellationToken);
		}

		public async Task<PostCommentResponse?> GetPostCommentCacheByIdAsync(
			DeletePostCommentLikeCommandRequest request,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostCommentCacheByIdAsync(request.Id, request.CommentId, request.UserId, cancellationToken);
		}

		public async Task SetupAddAsync(
			AddPostCommentLikeCommandRequest request,
			User user,
			Post post,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupAddPostCommentLikeAsync(user, post, postComment, request.UserId, cancellationToken);
		}

		public async Task AddPostCommentCacheAsync(
			AddPostCommentLikeCommandRequest request,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddPostCommentCacheAsync(postComment, request.UserId, cancellationToken);
		}

		public async Task AddPostCommentCacheAsync(
			DeletePostCommentLikeCommandRequest request,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddPostCommentCacheAsync(postComment, request.UserId, cancellationToken);
		}

		public async Task SetupDeleteAsync(
			DeletePostCommentLikeCommandRequest request,
			User user,
			Post post,
			PostComment postComment,
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupDeletePostCommentLikeAsync(user, post, postComment, postCommentLike, request.UserId, cancellationToken);
		}

		public async Task AddPostCommentLikeCacheAsync(
			DeletePostCommentLikeCommandRequest request,
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddPostCommentLikeCacheAsync(postCommentLike, request.UserId, cancellationToken);
		}

		public async Task SetupGetAllAsync(
			GetAllPostCommentLikesQueryRequest request,
			ICollection<User> users,
			ICollection<Post> posts,
			ICollection<PostLike> postLikes,
			ICollection<PostImage> postImages,
			ICollection<PostComment> postComments,
			ICollection<PostCommentLike> postCommentLikes,
			ICollection<PostCommentImage> postCommentImages,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetAllPostCommentLikesAsync(users, posts, postLikes, postImages, postComments, postCommentLikes, postCommentImages, cancellationToken);
		}

		public async Task SetupGetAllForUserAsync(
			GetAllPostCommentLikesForUserQueryRequest request,
			ICollection<User> users,
			ICollection<Post> posts,
			ICollection<PostLike> postLikes,
			ICollection<PostImage> postImages,
			ICollection<PostComment> postComments,
			ICollection<PostCommentLike> postCommentLikes,
			ICollection<PostCommentImage> postCommentImages,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetAllPostCommentLikesForUserAsync(users, posts, postLikes, postImages, postComments, postCommentLikes, postCommentImages, cancellationToken);
		}

		public async Task SetupGetByIdAsync(
			GetPostCommentLikeByIdQueryRequest request,
			User user,
			Post post,
			PostComment postComment,
			PostCommentLike postCommentLike,
			ICollection<PostCommentImage> postCommentImages,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetPostCommentLikeByIdAsync(user, post, postComment, postCommentLike, postCommentImages, cancellationToken);
		}
	}
}
