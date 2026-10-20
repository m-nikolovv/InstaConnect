using InstaConnect.Posts.Tests.Features.PostComments.Assertions;
using InstaConnect.Posts.Tests.Features.Posts.Assertions;

namespace InstaConnect.Posts.Domain.Tests.Features.PostComments.Assertions;

public static class PostCommentExceptionAssertions
{
	extension(IPostCommentCommandService service)
	{
		public async Task ShouldThrowUserNotFoundExceptionAsync(
			AddPostCommentCommand request,
			CancellationToken cancellationToken)
		{
			var func = () => service.AddAsync(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				request,
				r => r.UserId,
				cancellationToken);
		}

		public async Task ShouldThrowPostNotFoundExceptionAsync(
			AddPostCommentCommand request,
			CancellationToken cancellationToken)
		{
			var func = () => service.AddAsync(request, cancellationToken);

			await func.ShouldThrowPostNotFoundExceptionAsync(
				request,
				r => r.Id,
				cancellationToken);
		}

		public async Task ShouldThrowPostNotFoundExceptionAsync(
			UpdatePostCommentCommand request,
			CancellationToken cancellationToken)
		{
			var func = () => service.UpdateAsync(request, cancellationToken);

			await func.ShouldThrowPostNotFoundExceptionAsync(
				request,
				r => r.Id.Id,
				cancellationToken);
		}

		public async Task ShouldThrowPostNotFoundExceptionAsync(
			DeletePostCommentCommand request,
			CancellationToken cancellationToken)
		{
			var func = () => service.DeleteAsync(request, cancellationToken);

			await func.ShouldThrowPostNotFoundExceptionAsync(
				request,
				r => r.Id.Id,
				cancellationToken);
		}

		public async Task ShouldThrowPostCommentNotFoundExceptionAsync(
			UpdatePostCommentCommand request,
			CancellationToken cancellationToken)
		{
			var func = () => service.UpdateAsync(request, cancellationToken);

			await func.ShouldThrowPostCommentNotFoundExceptionAsync(
				request,
				r => r.Id,
				cancellationToken);
		}

		public async Task ShouldThrowPostCommentNotFoundExceptionAsync(
			DeletePostCommentCommand request,
			CancellationToken cancellationToken)
		{
			var func = () => service.DeleteAsync(request, cancellationToken);

			await func.ShouldThrowPostCommentNotFoundExceptionAsync(
				request,
				r => r.Id,
				cancellationToken);
		}

		public async Task ShouldThrowPostCommentForbiddenExceptionAsync(
			UpdatePostCommentCommand request,
			CancellationToken cancellationToken)
		{
			var func = () => service.UpdateAsync(request, cancellationToken);

			await func.ShouldThrowPostCommentForbiddenExceptionAsync(
				request,
				r => r.Id,
				r => r.UserId,
				cancellationToken);
		}

		public async Task ShouldThrowPostCommentForbiddenExceptionAsync(
			DeletePostCommentCommand request,
			CancellationToken cancellationToken)
		{
			var func = () => service.DeleteAsync(request, cancellationToken);

			await func.ShouldThrowPostCommentForbiddenExceptionAsync(
				request,
				r => r.Id,
				r => r.UserId,
				cancellationToken);
		}
	}

	extension(IPostCommentQueryService service)
	{
		public async Task ShouldThrowPostNotFoundExceptionAsync(
			GetAllPostCommentsQuery request,
			CancellationToken cancellationToken)
		{
			var func = () => service.GetAllAsync(request, cancellationToken);

			await func.ShouldThrowPostNotFoundExceptionAsync(
				request,
				r => r.Filter.Id,
				cancellationToken);
		}

		public async Task ShouldThrowPostNotFoundExceptionAsync(
			GetPostCommentByIdQuery request,
			CancellationToken cancellationToken)
		{
			var func = () => service.GetByIdAsync(request, cancellationToken);

			await func.ShouldThrowPostNotFoundExceptionAsync(
				request,
				r => r.Id.Id,
				cancellationToken);
		}

		public async Task ShouldThrowUserNotFoundExceptionAsync(
			GetAllPostCommentsForUserQuery request,
			CancellationToken cancellationToken)
		{
			var func = () => service.GetAllForUserAsync(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				request,
				r => r.Filter.UserId,
				cancellationToken);
		}

		public async Task ShouldThrowPostCommentNotFoundExceptionAsync(
			GetPostCommentByIdQuery request,
			CancellationToken cancellationToken)
		{
			var func = () => service.GetByIdAsync(request, cancellationToken);

			await func.ShouldThrowPostCommentNotFoundExceptionAsync(
				request,
				r => r.Id,
				cancellationToken);
		}
	}
}
