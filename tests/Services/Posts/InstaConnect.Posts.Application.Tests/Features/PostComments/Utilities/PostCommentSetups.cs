using InstaConnect.Posts.Application.Features.PostComments.Models;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Responses;
using InstaConnect.Posts.Domain.Features.Posts.Models.Responses;
using InstaConnect.Posts.Infrastructure.Features.PostComments.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;

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
	}

	extension(IPostCommentCacheHandler cacheHandler)
	{
		public async Task<PostCommentResponse?> GetByIdAsync(
			UpdatePostCommentCommandRequest request,
			CancellationToken cancellationToken)
		{
			return await cacheHandler.GetByIdAsync(request.Id, request.CommentId, request.UserId, cancellationToken);
		}

		public async Task<PostCommentResponse?> GetByIdAsync(
			DeletePostCommentCommandRequest request,
			CancellationToken cancellationToken)
		{
			return await cacheHandler.GetByIdAsync(request.Id, request.CommentId, request.UserId, cancellationToken);
		}

		public async Task<PostCommentResponse?> GetByIdAsync(
			GetPostCommentByIdQueryRequest request,
			CancellationToken cancellationToken)
		{
			return await cacheHandler.GetByIdAsync(request.Id, request.CommentId, request.CurrentUserId, cancellationToken);
		}

		public async Task AddAsync(
			UpdatePostCommentCommandRequest request,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await cacheHandler.AddAsync(postComment, request.UserId, cancellationToken);
		}

		public async Task AddAsync(
			DeletePostCommentCommandRequest request,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await cacheHandler.AddAsync(postComment, request.UserId, cancellationToken);
		}
	}

	extension(IPostCacheHandler cacheHandler)
	{
		public async Task<PostResponse?> GetByIdAsync(
			AddPostCommentCommandRequest request,
			CancellationToken cancellationToken)
		{
			return await cacheHandler.GetByIdAsync(request.Id, request.UserId, cancellationToken);
		}

		public async Task<PostResponse?> GetByIdAsync(
			DeletePostCommentCommandRequest request,
			CancellationToken cancellationToken)
		{
			return await cacheHandler.GetByIdAsync(request.Id, request.UserId, cancellationToken);
		}
	}
}
