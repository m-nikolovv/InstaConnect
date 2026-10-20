using InstaConnect.Posts.Presentation.Features.PostComments.Controllers.v1;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostComments.Assertions;

public static class PostCommentExceptionAssertions
{
	extension(PostCommentController controller)
	{
		public async Task ShouldThrowUserNotFoundExceptionAsync(
			AddPostCommentApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.AddAsync(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				request,
				r => r.UserId,
				cancellationToken);
		}

		public async Task ShouldThrowPostNotFoundExceptionAsync(
			AddPostCommentApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.AddAsync(request, cancellationToken);

			await func.ShouldThrowPostNotFoundExceptionAsync(
				request,
				r => r.Id,
				cancellationToken);
		}

		public async Task ShouldThrowPostNotFoundExceptionAsync(
			UpdatePostCommentApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.UpdateAsync(request, cancellationToken);

			await func.ShouldThrowPostNotFoundExceptionAsync(
				request,
				r => r.Id,
				cancellationToken);
		}

		public async Task ShouldThrowPostNotFoundExceptionAsync(
			DeletePostCommentApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.DeleteAsync(request, cancellationToken);

			await func.ShouldThrowPostNotFoundExceptionAsync(
				request,
				r => r.Id,
				cancellationToken);
		}

		public async Task ShouldThrowPostNotFoundExceptionAsync(
			GetPostCommentByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.GetByIdAsync(request, cancellationToken);

			await func.ShouldThrowPostNotFoundExceptionAsync(
				request,
				r => r.Id,
				cancellationToken);
		}

		public async Task ShouldThrowPostNotFoundExceptionAsync(
			GetAllPostCommentsApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.GetAllAsync(request, cancellationToken);

			await func.ShouldThrowPostNotFoundExceptionAsync(
				request,
				r => r.Id,
				cancellationToken);
		}

		public async Task ShouldThrowPostCommentNotFoundExceptionAsync(
			UpdatePostCommentApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.UpdateAsync(request, cancellationToken);

			await func.ShouldThrowPostCommentNotFoundExceptionAsync(
				request,
				r => r.Id,
				r => r.CommentId,
				cancellationToken);
		}

		public async Task ShouldThrowPostCommentNotFoundExceptionAsync(
			DeletePostCommentApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.DeleteAsync(request, cancellationToken);

			await func.ShouldThrowPostCommentNotFoundExceptionAsync(
				request,
				r => r.Id,
				r => r.CommentId,
				cancellationToken);
		}

		public async Task ShouldThrowPostCommentNotFoundExceptionAsync(
			GetPostCommentByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.GetByIdAsync(request, cancellationToken);

			await func.ShouldThrowPostCommentNotFoundExceptionAsync(
				request,
				r => r.Id,
				r => r.CommentId,
				cancellationToken);
		}

		public async Task ShouldThrowPostCommentForbiddenExceptionAsync(
			UpdatePostCommentApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.UpdateAsync(request, cancellationToken);

			await func.ShouldThrowPostCommentForbiddenExceptionAsync(
				request,
				r => r.Id,
				r => r.CommentId,
				r => r.UserId,
				cancellationToken);
		}

		public async Task ShouldThrowPostCommentForbiddenExceptionAsync(
			DeletePostCommentApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.DeleteAsync(request, cancellationToken);

			await func.ShouldThrowPostCommentForbiddenExceptionAsync(
				request,
				r => r.Id,
				r => r.CommentId,
				r => r.UserId,
				cancellationToken);
		}
	}

	extension(UserPostCommentController controller)
	{
		public async Task ShouldThrowUserNotFoundExceptionAsync(
			GetAllPostCommentsForUserApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.GetAllAsync(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				request,
				r => r.UserId,
				cancellationToken);
		}
	}
}
