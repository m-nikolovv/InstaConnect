namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Assertions;

public static class PostExceptionAssertions
{
	extension(PostController controller)
	{
		public async Task ShouldThrowUserNotFoundExceptionAsync(
			AddPostApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.AddAsync(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				request,
				r => r.UserId,
				cancellationToken);
		}

		public async Task ShouldThrowPostNotFoundExceptionAsync(
			UpdatePostApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.UpdateAsync(request, cancellationToken);

			await func.ShouldThrowPostNotFoundExceptionAsync(
				request,
				r => r.Id,
				cancellationToken);
		}

		public async Task ShouldThrowPostNotFoundExceptionAsync(
			DeletePostApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.DeleteAsync(request, cancellationToken);

			await func.ShouldThrowPostNotFoundExceptionAsync(
				request,
				r => r.Id,
				cancellationToken);
		}

		public async Task ShouldThrowPostNotFoundExceptionAsync(
			GetPostByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.GetByIdAsync(request, cancellationToken);

			await func.ShouldThrowPostNotFoundExceptionAsync(
				request,
				r => r.Id,
				cancellationToken);
		}

		public async Task ShouldThrowPostForbiddenExceptionAsync(
			UpdatePostApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.UpdateAsync(request, cancellationToken);

			await func.ShouldThrowPostForbiddenExceptionAsync(
				request,
				r => r.Id,
				r => r.UserId,
				cancellationToken);
		}

		public async Task ShouldThrowPostForbiddenExceptionAsync(
			DeletePostApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.DeleteAsync(request, cancellationToken);

			await func.ShouldThrowPostForbiddenExceptionAsync(
				request,
				r => r.Id,
				r => r.UserId,
				cancellationToken);
		}
	}

	extension(UserPostController controller)
	{
		public async Task ShouldThrowUserNotFoundExceptionAsync(
			GetAllPostsForUserApiRequest request,
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
