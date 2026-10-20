namespace InstaConnect.Posts.Application.Tests.Features.PostComments.Assertions;

public static class PostCommentExceptionAssertions
{
	extension(IApplicationSender sender)
	{
		public async Task ShouldThrowUserNotFoundExceptionAsync(
			AddPostCommentCommandRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				request,
				r => r.UserId,
				cancellationToken);
		}

		public async Task ShouldThrowUserNotFoundExceptionAsync(
			GetAllPostCommentsForUserQueryRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				request,
				r => r.UserId,
				cancellationToken);
		}

		public async Task ShouldThrowPostNotFoundExceptionAsync(
			AddPostCommentCommandRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowPostNotFoundExceptionAsync(
				request,
				r => r.Id,
				cancellationToken);
		}

		public async Task ShouldThrowPostNotFoundExceptionAsync(
			UpdatePostCommentCommandRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowPostNotFoundExceptionAsync(
				request,
				r => r.Id,
				cancellationToken);
		}

		public async Task ShouldThrowPostNotFoundExceptionAsync(
			DeletePostCommentCommandRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowPostNotFoundExceptionAsync(
				request,
				r => r.Id,
				cancellationToken);
		}

		public async Task ShouldThrowPostNotFoundExceptionAsync(
			GetPostCommentByIdQueryRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowPostNotFoundExceptionAsync(
				request,
				r => r.Id,
				cancellationToken);
		}

		public async Task ShouldThrowPostNotFoundExceptionAsync(
			GetAllPostCommentsQueryRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowPostNotFoundExceptionAsync(
				request,
				r => r.Id,
				cancellationToken);
		}

		public async Task ShouldThrowPostCommentNotFoundExceptionAsync(
			UpdatePostCommentCommandRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowPostCommentNotFoundExceptionAsync(
				request,
				r => r.Id,
				r => r.CommentId,
				cancellationToken);
		}

		public async Task ShouldThrowPostCommentNotFoundExceptionAsync(
			DeletePostCommentCommandRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowPostCommentNotFoundExceptionAsync(
				request,
				r => r.Id,
				r => r.CommentId,
				cancellationToken);
		}

		public async Task ShouldThrowPostCommentNotFoundExceptionAsync(
			GetPostCommentByIdQueryRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowPostCommentNotFoundExceptionAsync(
				request,
				r => r.Id,
				r => r.CommentId,
				cancellationToken);
		}

		public async Task ShouldThrowPostCommentForbiddenExceptionAsync(
			DeletePostCommentCommandRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowPostCommentForbiddenExceptionAsync(
				request,
				r => r.Id,
				r => r.CommentId,
				r => r.UserId,
				cancellationToken);
		}

		public async Task ShouldThrowPostCommentForbiddenExceptionAsync(
			UpdatePostCommentCommandRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowPostCommentForbiddenExceptionAsync(
				request,
				r => r.Id,
				r => r.CommentId,
				r => r.UserId,
				cancellationToken);
		}
	}
}
