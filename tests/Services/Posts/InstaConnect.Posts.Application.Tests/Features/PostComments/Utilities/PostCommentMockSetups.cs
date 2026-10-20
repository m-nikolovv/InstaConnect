using InstaConnect.Posts.Domain.Features.PostComments.Abstractions;
using InstaConnect.Posts.Domain.Tests.Features.PostComments.Utilities;

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

		public void SetupGetAllForUserAsync(
			GetAllPostCommentsForUserQueryRequest request,
			User user,
			ICollection<PostComment> postComments,
			CancellationToken cancellationToken)
		{
			commentService.SetupGetAllForUserAsync(request.IsGetAllPostCommentsForUserQuery(), postComments.ToResponse(request, user), cancellationToken);
		}

		public void SetupGetByIdAsync(
			GetPostCommentByIdQueryRequest request,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			commentService.SetupGetByIdAsync(request.IsGetPostCommentByIdQuery(), postComment.ToResponse(request), cancellationToken);
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

		public void SetupUpdateAsync(
			UpdatePostCommentCommandRequest request,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			commentService.SetupUpdateAsync(request.IsUpdatePostCommentCommand(), postComment.ToResponse(request), cancellationToken);
		}
	}
}
