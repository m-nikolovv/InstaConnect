using InstaConnect.Posts.Tests.Features.PostLikes.Assertions;
using InstaConnect.Posts.Tests.Features.Posts.Assertions;

namespace InstaConnect.Posts.Domain.Tests.Features.PostLikes.Assertions;

public static class PostLikeExceptionAssertions
{
	extension(IPostLikeCommandService service)
	{
		public async Task ShouldThrowUserNotFoundExceptionAsync(
			AddPostLikeCommand request,
			CancellationToken cancellationToken)
		{
			var func = () => service.AddAsync(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				request,
				r => r.UserId,
				cancellationToken);
		}

		public async Task ShouldThrowPostNotFoundExceptionAsync(
			AddPostLikeCommand request,
			CancellationToken cancellationToken)
		{
			var func = () => service.AddAsync(request, cancellationToken);

			await func.ShouldThrowPostNotFoundExceptionAsync(
				request,
				r => r.Id,
				cancellationToken);
		}

		public async Task ShouldThrowPostNotFoundExceptionAsync(
			DeletePostLikeCommand request,
			CancellationToken cancellationToken)
		{
			var func = () => service.DeleteAsync(request, cancellationToken);

			await func.ShouldThrowPostNotFoundExceptionAsync(
				request,
				r => r.Id.Id,
				cancellationToken);
		}

		public async Task ShouldThrowPostLikeAlreadyExistsExceptionAsync(
			AddPostLikeCommand request,
			CancellationToken cancellationToken)
		{
			var func = () => service.AddAsync(request, cancellationToken);

			await func.ShouldThrowPostLikeAlreadyExistsExceptionAsync(
				request,
				r => r.Id.Id,
				r => r.UserId.Id,
				cancellationToken);
		}

		public async Task ShouldThrowPostLikeNotFoundExceptionAsync(
			DeletePostLikeCommand request,
			CancellationToken cancellationToken)
		{
			var func = () => service.DeleteAsync(request, cancellationToken);

			await func.ShouldThrowPostLikeNotFoundExceptionAsync(
				request,
				r => r.Id,
				cancellationToken);
		}
	}

	extension(IPostLikeQueryService service)
	{
		public async Task ShouldThrowPostNotFoundExceptionAsync(
			GetAllPostLikesQuery request,
			CancellationToken cancellationToken)
		{
			var func = () => service.GetAllAsync(request, cancellationToken);

			await func.ShouldThrowPostNotFoundExceptionAsync(
				request,
				r => r.Filter.Id,
				cancellationToken);
		}

		public async Task ShouldThrowPostNotFoundExceptionAsync(
			GetPostLikeByIdQuery request,
			CancellationToken cancellationToken)
		{
			var func = () => service.GetByIdAsync(request, cancellationToken);

			await func.ShouldThrowPostNotFoundExceptionAsync(
				request,
				r => r.Id.Id,
				cancellationToken);
		}

		public async Task ShouldThrowUserNotFoundExceptionAsync(
			GetAllPostLikesForUserQuery request,
			CancellationToken cancellationToken)
		{
			var func = () => service.GetAllForUserAsync(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				request,
				r => r.Filter.UserId,
				cancellationToken);
		}

		public async Task ShouldThrowPostLikeNotFoundExceptionAsync(
			GetPostLikeByIdQuery request,
			CancellationToken cancellationToken)
		{
			var func = () => service.GetByIdAsync(request, cancellationToken);

			await func.ShouldThrowPostLikeNotFoundExceptionAsync(
				request,
				r => r.Id,
				cancellationToken);
		}
	}
}
