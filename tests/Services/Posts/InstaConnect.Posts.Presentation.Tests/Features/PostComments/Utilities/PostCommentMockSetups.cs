using InstaConnect.Common.Application.Tests.Features.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostComments.Utilities;

public static class PostCommentMockSetups
{
	extension(IApplicationSender sender)
	{
		public void SetupSendAsync(
		GetAllPostCommentsApiRequest request,
		Post post,
		ICollection<PostComment> postComments,
		CancellationToken cancellationToken)
		{
			sender.SetupSendAsync(request.IsGetAllPostCommentsQueryRequest(), postComments.ToResponse(request, post), cancellationToken);
		}

		public void SetupSendAsync(
			GetAllPostCommentsForUserApiRequest request,
			User user,
			ICollection<PostComment> postComments,
			CancellationToken cancellationToken)
		{
			sender.SetupSendAsync(request.IsGetAllPostCommentsForUserQueryRequest(), postComments.ToResponse(request, user), cancellationToken);
		}

		public void SetupSendAsync(
			GetPostCommentByIdApiRequest request,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			sender.SetupSendAsync(request.IsGetPostCommentByIdQueryRequest(), postComment.ToResponse(request), cancellationToken);
		}

		public void SetupSendAsync(
			AddPostCommentApiRequest request,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			sender.SetupSendAsync(request.IsAddPostCommentCommandRequest(), postComment.ToResponse(request), cancellationToken);
		}

		public void SetupSendAsync(
			UpdatePostCommentApiRequest request,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			sender.SetupSendAsync(request.IsUpdatePostCommentCommandRequest(), postComment.ToResponse(request), cancellationToken);
		}
	}
}
