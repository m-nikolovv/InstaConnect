using InstaConnect.Posts.Tests.Features.PostCommentLikes.Assertions;
using InstaConnect.Posts.Tests.Features.PostComments.Assertions;
using InstaConnect.Posts.Tests.Features.Posts.Assertions;

namespace InstaConnect.Posts.Domain.Tests.Features.PostCommentLikes.Assertions;

public static class PostCommentLikeExceptionAssertions
{
	extension(IPostCommentLikeCommandService service)
	{
		public async Task ShouldThrowUserNotFoundExceptionAsync(
			AddPostCommentLikeCommand request,
			CancellationToken cancellationToken)
		{
			var func = () => service.AddAsync(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				request,
				r => r.UserId,
				cancellationToken);
		}

		public async Task ShouldThrowPostNotFoundExceptionAsync(
			AddPostCommentLikeCommand request,
			CancellationToken cancellationToken)
		{
			var func = () => service.AddAsync(request, cancellationToken);

			await func.ShouldThrowPostNotFoundExceptionAsync(
				request,
				r => r.CommentId.Id,
				cancellationToken);
		}

		public async Task ShouldThrowPostNotFoundExceptionAsync(
			DeletePostCommentLikeCommand request,
			CancellationToken cancellationToken)
		{
			var func = () => service.DeleteAsync(request, cancellationToken);

			await func.ShouldThrowPostNotFoundExceptionAsync(
				request,
				r => r.Id.CommentId.Id,
				cancellationToken);
		}

		public async Task ShouldThrowPostCommentNotFoundExceptionAsync(
			AddPostCommentLikeCommand request,
			CancellationToken cancellationToken)
		{
			var func = () => service.AddAsync(request, cancellationToken);

			await func.ShouldThrowPostCommentNotFoundExceptionAsync(
				request,
				r => r.CommentId,
				cancellationToken);
		}

		public async Task ShouldThrowPostCommentNotFoundExceptionAsync(
			DeletePostCommentLikeCommand request,
			CancellationToken cancellationToken)
		{
			var func = () => service.DeleteAsync(request, cancellationToken);

			await func.ShouldThrowPostCommentNotFoundExceptionAsync(
				request,
				r => r.Id.CommentId,
				cancellationToken);
		}

		public async Task ShouldThrowPostCommentLikeAlreadyExistsExceptionAsync(
			AddPostCommentLikeCommand request,
			CancellationToken cancellationToken)
		{
			var func = () => service.AddAsync(request, cancellationToken);

			await func.ShouldThrowPostCommentLikeAlreadyExistsExceptionAsync(
				request,
				r => r.CommentId.Id.Id,
				r => r.CommentId.CommentId,
				r => r.UserId.Id,
				cancellationToken);
		}

		public async Task ShouldThrowPostCommentLikeNotFoundExceptionAsync(
			DeletePostCommentLikeCommand request,
			CancellationToken cancellationToken)
		{
			var func = () => service.DeleteAsync(request, cancellationToken);

			await func.ShouldThrowPostCommentLikeNotFoundExceptionAsync(
				request,
				r => r.Id,
				cancellationToken);
		}
	}

	extension(IPostCommentLikeQueryService service)
	{
		public async Task ShouldThrowPostNotFoundExceptionAsync(
			GetAllPostCommentLikesQuery request,
			CancellationToken cancellationToken)
		{
			var func = () => service.GetAllAsync(request, cancellationToken);

			await func.ShouldThrowPostNotFoundExceptionAsync(
				request,
				r => r.Filter.CommentId.Id,
				cancellationToken);
		}

		public async Task ShouldThrowPostNotFoundExceptionAsync(
			GetPostCommentLikeByIdQuery request,
			CancellationToken cancellationToken)
		{
			var func = () => service.GetByIdAsync(request, cancellationToken);

			await func.ShouldThrowPostNotFoundExceptionAsync(
				request,
				r => r.Id.CommentId.Id,
				cancellationToken);
		}

		public async Task ShouldThrowPostCommentNotFoundExceptionAsync(
			GetAllPostCommentLikesQuery request,
			CancellationToken cancellationToken)
		{
			var func = () => service.GetAllAsync(request, cancellationToken);

			await func.ShouldThrowPostCommentNotFoundExceptionAsync(
				request,
				r => r.Filter.CommentId,
				cancellationToken);
		}

		public async Task ShouldThrowPostCommentNotFoundExceptionAsync(
			GetPostCommentLikeByIdQuery request,
			CancellationToken cancellationToken)
		{
			var func = () => service.GetByIdAsync(request, cancellationToken);

			await func.ShouldThrowPostCommentNotFoundExceptionAsync(
				request,
				r => r.Id.CommentId,
				cancellationToken);
		}

		public async Task ShouldThrowUserNotFoundExceptionAsync(
			GetAllPostCommentLikesForUserQuery request,
			CancellationToken cancellationToken)
		{
			var func = () => service.GetAllForUserAsync(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				request,
				r => r.Filter.UserId,
				cancellationToken);
		}

		public async Task ShouldThrowPostCommentLikeNotFoundExceptionAsync(
			GetPostCommentLikeByIdQuery request,
			CancellationToken cancellationToken)
		{
			var func = () => service.GetByIdAsync(request, cancellationToken);

			await func.ShouldThrowPostCommentLikeNotFoundExceptionAsync(
				request,
				r => r.Id,
				cancellationToken);
		}
	}
}
