using InstaConnect.Posts.Domain.Tests.Features.Posts.Assertions;
using InstaConnect.Posts.Tests.Features.Posts.Assertions;
using InstaConnect.Posts.Tests.Features.Users.Assertions;

namespace InstaConnect.Posts.Domain.Tests.Features.Posts.Assertions;

public static class PostExceptionAssertions
{
	extension(IPostQueryService service)
	{
		public async Task ShouldThrowUserNotFoundExceptionAsync(
		GetAllPostsForUserQuery request,
		CancellationToken cancellationToken)
		{
			var func = () => service.GetAllForUserAsync(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				request,
				r => r.Filter.UserId,
				cancellationToken);
		}

		public async Task ShouldThrowPostNotFoundExceptionAsync(
			GetPostByIdQuery request,
			CancellationToken cancellationToken)
		{
			var func = () => service.GetByIdAsync(request, cancellationToken);

			await func.ShouldThrowPostNotFoundExceptionAsync(
				request,
				r => r.Id,
				cancellationToken);
		}
	}

	extension(IPostCommandService service)
	{
		public async Task ShouldThrowUserNotFoundExceptionAsync(
			AddPostCommand request,
			CancellationToken cancellationToken)
		{
			var func = () => service.AddAsync(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				request,
				r => r.UserId,
				cancellationToken);
		}

		public async Task ShouldThrowPostNotFoundExceptionAsync(
			UpdatePostCommand request,
			CancellationToken cancellationToken)
		{
			var func = () => service.UpdateAsync(request, cancellationToken);

			await func.ShouldThrowPostNotFoundExceptionAsync(
				request,
				r => r.Id,
				cancellationToken);
		}

		public async Task ShouldThrowPostNotFoundExceptionAsync(
			DeletePostCommand request,
			CancellationToken cancellationToken)
		{
			var func = () => service.DeleteAsync(request, cancellationToken);

			await func.ShouldThrowPostNotFoundExceptionAsync(
				request,
				r => r.Id,
				cancellationToken);
		}

		public async Task ShouldThrowPostForbiddenExceptionAsync(
			UpdatePostCommand request,
			CancellationToken cancellationToken)
		{
			var func = () => service.UpdateAsync(request, cancellationToken);

			await func.ShouldThrowPostForbiddenExceptionAsync(
				request,
				r => r.Id,
				r => r.UserId,
				cancellationToken);
		}

		public async Task ShouldThrowPostForbiddenExceptionAsync(
			DeletePostCommand request,
			CancellationToken cancellationToken)
		{
			var func = () => service.DeleteAsync(request, cancellationToken);

			await func.ShouldThrowPostForbiddenExceptionAsync(
				request,
				r => r.Id,
				r => r.UserId,
				cancellationToken);
		}
	}
}
