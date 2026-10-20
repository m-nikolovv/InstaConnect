using InstaConnect.Posts.Presentation.Features.PostCommentLikes.Controllers.v1;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Assertions;

public static class PostCommentLikeExceptionAssertions
{
	extension(PostCommentLikeController controller)
	{
		public async Task ShouldThrowUserNotFoundExceptionAsync(
			AddPostCommentLikeApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.AddAsync(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				request,
				r => r.UserId,
				cancellationToken);
		}

		public async Task ShouldThrowPostNotFoundExceptionAsync(
			AddPostCommentLikeApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.AddAsync(request, cancellationToken);

			await func.ShouldThrowPostNotFoundExceptionAsync(
				request,
				r => r.Id,
				cancellationToken);
		}

		public async Task ShouldThrowPostNotFoundExceptionAsync(
			DeletePostCommentLikeApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.DeleteAsync(request, cancellationToken);

			await func.ShouldThrowPostNotFoundExceptionAsync(
				request,
				r => r.Id,
				cancellationToken);
		}

		public async Task ShouldThrowPostNotFoundExceptionAsync(
			GetPostCommentLikeByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.GetByIdAsync(request, cancellationToken);

			await func.ShouldThrowPostNotFoundExceptionAsync(
				request,
				r => r.Id,
				cancellationToken);
		}

		public async Task ShouldThrowPostNotFoundExceptionAsync(
			GetAllPostCommentLikesApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.GetAllAsync(request, cancellationToken);

			await func.ShouldThrowPostNotFoundExceptionAsync(
				request,
				r => r.Id,
				cancellationToken);
		}

		public async Task ShouldThrowPostCommentNotFoundExceptionAsync(
			AddPostCommentLikeApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.AddAsync(request, cancellationToken);

			await func.ShouldThrowPostCommentNotFoundExceptionAsync(
				request,
				r => r.Id,
				r => r.CommentId,
				cancellationToken);
		}

		public async Task ShouldThrowPostCommentNotFoundExceptionAsync(
			DeletePostCommentLikeApiRequest request,
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
			GetPostCommentLikeByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.GetByIdAsync(request, cancellationToken);

			await func.ShouldThrowPostCommentNotFoundExceptionAsync(
				request,
				r => r.Id,
				r => r.CommentId,
				cancellationToken);
		}

		public async Task ShouldThrowPostCommentNotFoundExceptionAsync(
			GetAllPostCommentLikesApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.GetAllAsync(request, cancellationToken);

			await func.ShouldThrowPostCommentNotFoundExceptionAsync(
				request,
				r => r.Id,
				r => r.CommentId,
				cancellationToken);
		}

		public async Task ShouldThrowPostCommentLikeNotFoundExceptionAsync(
			DeletePostCommentLikeApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.DeleteAsync(request, cancellationToken);

			await func.ShouldThrowPostCommentLikeNotFoundExceptionAsync(
				request,
				r => r.Id,
				r => r.CommentId,
				r => r.UserId,
				cancellationToken);
		}

		public async Task ShouldThrowPostCommentLikeNotFoundExceptionAsync(
			GetPostCommentLikeByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.GetByIdAsync(request, cancellationToken);

			await func.ShouldThrowPostCommentLikeNotFoundExceptionAsync(
				request,
				r => r.Id,
				r => r.CommentId,
				r => r.UserId,
				cancellationToken);
		}

		public async Task ShouldThrowPostCommentLikeAlreadyExistsExceptionAsync(
			AddPostCommentLikeApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.AddAsync(request, cancellationToken);

			await func.ShouldThrowPostCommentLikeAlreadyExistsExceptionAsync(
				request,
				r => r.Id,
				r => r.CommentId,
				r => r.UserId,
				cancellationToken);
		}
	}

	extension(UserPostCommentLikeController controller)
	{
		public async Task ShouldThrowUserNotFoundExceptionAsync(
			GetAllPostCommentLikesForUserApiRequest request,
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
