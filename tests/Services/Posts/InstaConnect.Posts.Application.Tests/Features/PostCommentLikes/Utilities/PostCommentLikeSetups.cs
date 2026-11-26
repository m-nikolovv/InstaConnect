using InstaConnect.Posts.Application.Features.PostCommentLikes.Models;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Responses;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.ValueObjects;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Responses;

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

		public async Task InitializeAddAsync(
			AddPostCommentLikeCommandRequest request,
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeAddAsync(postCommentLike, request.UserId, cancellationToken);
		}

		public async Task DisposeAddAsync(
			AddPostCommentLikeCommandRequest request,
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeAddAsync(postCommentLike, cancellationToken);
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

		public async Task InitializeDeleteAsync(
			DeletePostCommentLikeCommandRequest request,
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeDeleteAsync(postCommentLike, request.UserId, cancellationToken);
		}

		public async Task DisposeDeleteAsync(
			DeletePostCommentLikeCommandRequest request,
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeDeleteAsync(postCommentLike, cancellationToken);
		}

		public async Task AddPostCommentLikeCacheAsync(
			DeletePostCommentLikeCommandRequest request,
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddPostCommentLikeCacheAsync(postCommentLike, request.UserId, cancellationToken);
		}

		public async Task InitializeGetAllAsync(
			GetAllPostCommentLikesQueryRequest request,
			ICollection<PostCommentLike> postCommentLikes,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeGetAllAsync(postCommentLikes, cancellationToken);
		}

		public async Task DisposeGetAllAsync(
			GetAllPostCommentLikesQueryRequest request,
			ICollection<PostCommentLike> postCommentLikes,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeGetAllAsync(postCommentLikes, cancellationToken);
		}

		public async Task InitializeGetAllForUserAsync(
			GetAllPostCommentLikesForUserQueryRequest request,
			ICollection<PostCommentLike> postCommentLikes,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeGetAllForUserAsync(postCommentLikes, cancellationToken);
		}

		public async Task DisposeGetAllForUserAsync(
			GetAllPostCommentLikesForUserQueryRequest request,
			ICollection<PostCommentLike> postCommentLikes,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeGetAllForUserAsync(postCommentLikes, cancellationToken);
		}

		public async Task InitializeGetByIdAsync(
			GetPostCommentLikeByIdQueryRequest request,
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeGetByIdAsync(postCommentLike, cancellationToken);
		}

		public async Task DisposeGetByIdAsync(
			GetPostCommentLikeByIdQueryRequest request,
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeGetByIdAsync(postCommentLike, cancellationToken);
		}
	}
}
