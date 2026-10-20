using InstaConnect.Posts.Presentation.Features.PostLikes.Controllers.v1;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Assertions;

public static class PostLikeExceptionAssertions
{
	extension(PostLikeController controller)
	{
		public async Task ShouldThrowUserNotFoundExceptionAsync(
			AddPostLikeApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.AddAsync(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				request,
				r => r.UserId,
				cancellationToken);
		}

		public async Task ShouldThrowPostNotFoundExceptionAsync(
			AddPostLikeApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.AddAsync(request, cancellationToken);

			await func.ShouldThrowPostNotFoundExceptionAsync(
				request,
				r => r.Id,
				cancellationToken);
		}

		public async Task ShouldThrowPostNotFoundExceptionAsync(
			DeletePostLikeApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.DeleteAsync(request, cancellationToken);

			await func.ShouldThrowPostNotFoundExceptionAsync(
				request,
				r => r.Id,
				cancellationToken);
		}

		public async Task ShouldThrowPostNotFoundExceptionAsync(
			GetPostLikeByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.GetByIdAsync(request, cancellationToken);

			await func.ShouldThrowPostNotFoundExceptionAsync(
				request,
				r => r.Id,
				cancellationToken);
		}

		public async Task ShouldThrowPostNotFoundExceptionAsync(
			GetAllPostLikesApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.GetAllAsync(request, cancellationToken);

			await func.ShouldThrowPostNotFoundExceptionAsync(
				request,
				r => r.Id,
				cancellationToken);
		}

		public async Task ShouldThrowPostLikeNotFoundExceptionAsync(
			DeletePostLikeApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.DeleteAsync(request, cancellationToken);

			await func.ShouldThrowPostLikeNotFoundExceptionAsync(
				request,
				r => r.Id,
				r => r.UserId,
				cancellationToken);
		}

		public async Task ShouldThrowPostLikeNotFoundExceptionAsync(
			GetPostLikeByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.GetByIdAsync(request, cancellationToken);

			await func.ShouldThrowPostLikeNotFoundExceptionAsync(
				request,
				r => r.Id,
				r => r.UserId,
				cancellationToken);
		}

		public async Task ShouldThrowPostLikeAlreadyExistsExceptionAsync(
			AddPostLikeApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.AddAsync(request, cancellationToken);

			await func.ShouldThrowPostLikeAlreadyExistsExceptionAsync(
				request,
				r => r.Id,
				r => r.UserId,
				cancellationToken);
		}
	}

	extension(UserPostLikeController controller)
	{
		public async Task ShouldThrowUserNotFoundExceptionAsync(
			GetAllPostLikesForUserApiRequest request,
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
