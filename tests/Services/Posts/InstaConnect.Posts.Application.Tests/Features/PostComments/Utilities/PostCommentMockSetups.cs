using InstaConnect.Posts.Domain.Features.PostComments.Abstractions;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Responses;

namespace InstaConnect.Posts.Application.Tests.Features.PostComments.Utilities;

public static class PostCommentMockSetups
{
	extension(IPostCommentQueryService commentService)
	{
		public void SetupGetAllAsync(
		GetAllPostCommentsQueryRequest request,
		Post post,
		ICollection<PostComment> postComments,
		CancellationToken cancellationToken)
		{
			commentService.SetupGetAllAsync(request.IsGetAllPostCommentsQuery(), postComments.ToResponse(request, post), cancellationToken);
		}

		public void SetupGetAllAsync(
			GetAllPostCommentsQuery query,
			PostCommentCollectionResponse response,
			CancellationToken cancellationToken)
		{
			commentService
				.GetAllAsync(query, cancellationToken)
				.ReturnsTaskResponse(response);
		}

		public void SetupGetAllForUserAsync(
			GetAllPostCommentsForUserQueryRequest request,
			User user,
			ICollection<PostComment> postComments,
			CancellationToken cancellationToken)
		{
			commentService.SetupGetAllForUserAsync(request.IsGetAllPostCommentsForUserQuery(), postComments.ToResponse(request, user), cancellationToken);
		}

		public void SetupGetAllForUserAsync(
			GetAllPostCommentsForUserQuery query,
			PostCommentCollectionResponse response,
			CancellationToken cancellationToken)
		{
			commentService
				.GetAllForUserAsync(query, cancellationToken)
				.ReturnsTaskResponse(response);
		}

		public void SetupGetByIdAsync(
			GetPostCommentByIdQueryRequest request,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			commentService.SetupGetByIdAsync(request.IsGetPostCommentByIdQuery(), postComment.ToResponse(request), cancellationToken);
		}

		public void SetupGetByIdAsync(
			GetPostCommentByIdQuery query,
			PostCommentResponse response,
			CancellationToken cancellationToken)
		{
			commentService
				.GetByIdAsync(query, cancellationToken)
				.ReturnsTaskResponse(response);
		}
	}

	extension(IPostCommentCommandService commentService)
	{
		public void SetupAddAsync(
		AddPostCommentCommandRequest request,
		PostComment postComment,
		CancellationToken cancellationToken)
		{
			commentService.SetupAddAsync(request.IsAddPostCommentCommand(), postComment.ToResponse(request), cancellationToken);
		}

		public void SetupAddAsync(
			AddPostCommentCommand command,
			PostCommentId id,
			CancellationToken cancellationToken)
		{
			commentService
				.AddAsync(command, cancellationToken)
				.ReturnsTaskResponse(id);
		}

		public void SetupUpdateAsync(
			UpdatePostCommentCommandRequest request,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			commentService.SetupUpdateAsync(request.IsUpdatePostCommentCommand(), postComment.ToResponse(request), cancellationToken);
		}

		public void SetupUpdateAsync(
			UpdatePostCommentCommand command,
			PostCommentId id,
			CancellationToken cancellationToken)
		{
			commentService
				.UpdateAsync(command, cancellationToken)
				.ReturnsTaskResponse(id);
		}
	}
}
