namespace InstaConnect.Posts.Presentation.Tests.Features.PostComments.Assertions;

public static class PostCommentMockAssertions
{
	extension(IApplicationSender sender)
	{
		public async Task ShouldHaveReceivedOneSendAsync(
		GetAllPostCommentsApiRequest request,
		CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOneSendAsync(request.IsGetAllPostCommentsQueryRequest(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneSendAsync(
			GetAllPostCommentsForUserApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOneSendAsync(request.IsGetAllPostCommentsForUserQueryRequest(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneSendAsync(
			GetPostCommentByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOneSendAsync(request.IsGetPostCommentByIdQueryRequest(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneSendAsync(
			AddPostCommentApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOneSendAsync(request.IsAddPostCommentCommandRequest(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneSendAsync(
			UpdatePostCommentApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOneSendAsync(request.IsUpdatePostCommentCommandRequest(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneSendAsync(
			DeletePostCommentApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOneSendAsync(request.IsDeletePostCommentCommandRequest(), cancellationToken);
		}
	}
}
