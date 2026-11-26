using InstaConnect.Posts.Application.Features.PostComments.Models;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Responses;
using InstaConnect.Posts.Domain.Features.Posts.Models.Responses;

namespace InstaConnect.Posts.Application.Tests.Features.PostComments.Utilities;

public static class PostCommentSetups
{
	extension(IServiceScope serviceScope)
	{
		internal async Task<PostComment?> GetByIdAsync(
		PostCommentIdCommandResponse id,
		CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				new PostCommentId(
							   new(id.Id),
							   id.CommentId),
				cancellationToken);
		}

		public async Task<PostComment?> GetByIdAsync(
			AddPostCommentCommandResponse response,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				response.Response,
				cancellationToken);
		}

		public async Task<PostComment?> GetByIdAsync(
			UpdatePostCommentCommandResponse response,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				response.Response,
				cancellationToken);
		}

		public async Task InitializeAddAsync(
			AddPostCommentCommandRequest request,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeAddAsync(postComment, request.UserId, cancellationToken);
		}

		public async Task DisposeAddAsync(
			AddPostCommentCommandRequest request,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeAddAsync(postComment, cancellationToken);
		}

		public async Task InitializeUpdateAsync(
			UpdatePostCommentCommandRequest request,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeUpdateAsync(postComment, request.UserId, cancellationToken);
		}

		public async Task DisposeUpdateAsync(
			UpdatePostCommentCommandRequest request,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeUpdateAsync(postComment, cancellationToken);
		}

		public async Task InitializeDeleteAsync(
			DeletePostCommentCommandRequest request,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeDeleteAsync(postComment, request.UserId, cancellationToken);
		}

		public async Task DisposeDeleteAsync(
			DeletePostCommentCommandRequest request,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeDeleteAsync(postComment, cancellationToken);
		}

		public async Task InitializeGetByIdAsync(
			GetPostCommentByIdQueryRequest request,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeGetByIdAsync(postComment, cancellationToken);
		}

		public async Task DisposeGetByIdAsync(
			GetPostCommentByIdQueryRequest request,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeGetByIdAsync(postComment, cancellationToken);
		}

		public async Task InitializeGetAllAsync(
			GetAllPostCommentsQueryRequest request,
			ICollection<PostComment> postComments,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeGetAllAsync(postComments, cancellationToken);
		}

		public async Task DisposeGetAllAsync(
			GetAllPostCommentsQueryRequest request,
			ICollection<PostComment> postComments,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeGetAllAsync(postComments, cancellationToken);
		}

		public async Task InitializeGetAllForUserAsync(
			GetAllPostCommentsForUserQueryRequest request,
			ICollection<PostComment> postComments,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeGetAllForUserAsync(postComments, cancellationToken);
		}

		public async Task DisposeGetAllForUserAsync(
			GetAllPostCommentsForUserQueryRequest request,
			ICollection<PostComment> postComments,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeGetAllForUserAsync(postComments, cancellationToken);
		}

		public async Task<PostCommentResponse?> GetPostCommentCacheByIdAsync(
			UpdatePostCommentCommandRequest request,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostCommentCacheByIdAsync(request.Id, request.CommentId, request.UserId, cancellationToken);
		}

		public async Task<PostCommentResponse?> GetPostCommentCacheByIdAsync(
			DeletePostCommentCommandRequest request,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostCommentCacheByIdAsync(request.Id, request.CommentId, request.UserId, cancellationToken);
		}

		public async Task<PostCommentResponse?> GetPostCommentCacheByIdAsync(
			GetPostCommentByIdQueryRequest request,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostCommentCacheByIdAsync(request.Id, request.CommentId, request.CurrentUserId, cancellationToken);
		}

		public async Task AddPostCommentCacheAsync(
			UpdatePostCommentCommandRequest request,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddPostCommentCacheAsync(postComment, request.UserId, cancellationToken);
		}

		public async Task AddPostCommentCacheAsync(
			DeletePostCommentCommandRequest request,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddPostCommentCacheAsync(postComment, request.UserId, cancellationToken);
		}

		public async Task<PostResponse?> GetPostCacheByIdAsync(
			AddPostCommentCommandRequest request,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostCacheByIdAsync(request.Id, request.UserId, cancellationToken);
		}

		public async Task<PostResponse?> GetPostCacheByIdAsync(
			DeletePostCommentCommandRequest request,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostCacheByIdAsync(request.Id, request.UserId, cancellationToken);
		}
	}
}
