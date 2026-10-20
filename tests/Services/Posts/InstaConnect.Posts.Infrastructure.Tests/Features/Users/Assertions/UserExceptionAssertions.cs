using InstaConnect.Posts.Infrastructure.Features.Users.EventHandlers;

namespace InstaConnect.Posts.Infrastructure.Tests.Features.Users.Assertions;

public static class UserExceptionAssertions
{
	extension(UserAddedEventHandler handler)
	{
		public async Task ShouldThrowUserAlreadyExistsExceptionAsync(
			UserAddedEventRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => handler.Consume(request, cancellationToken);

			await func.ShouldThrowUserAlreadyExistsExceptionAsync(
				request,
				r => r.User.Id,
				cancellationToken);
		}

		public async Task ShouldThrowUserEmailAlreadyExistsExceptionAsync(
			UserAddedEventRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => handler.Consume(request, cancellationToken);

			await func.ShouldThrowUserEmailAlreadyExistsExceptionAsync(
				request,
				r => r.User.Email,
				cancellationToken);
		}

		public async Task ShouldThrowUserNameAlreadyExistsExceptionAsync(
			UserAddedEventRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => handler.Consume(request, cancellationToken);

			await func.ShouldThrowUserNameAlreadyExistsExceptionAsync(
				request,
				r => r.User.Name,
				cancellationToken);
		}
	}

	extension(UserUpdatedEventHandler handler)
	{
		public async Task ShouldThrowUserNotFoundExceptionAsync(
			UserUpdatedEventRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => handler.Consume(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				request,
				r => r.User.Id,
				cancellationToken);
		}

		public async Task ShouldThrowUserEmailAlreadyExistsExceptionAsync(
			UserUpdatedEventRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => handler.Consume(request, cancellationToken);

			await func.ShouldThrowUserEmailAlreadyExistsExceptionAsync(
				request,
				r => r.User.Email,
				cancellationToken);
		}

		public async Task ShouldThrowUserNameAlreadyExistsExceptionAsync(
			UserUpdatedEventRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => handler.Consume(request, cancellationToken);

			await func.ShouldThrowUserNameAlreadyExistsExceptionAsync(
				request,
				r => r.User.Name,
				cancellationToken);
		}
	}

	extension(UserDeletedEventHandler handler)
	{
		public async Task ShouldThrowUserNotFoundExceptionAsync(
			UserDeletedEventRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => handler.Consume(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				request,
				r => r.User.Id,
				cancellationToken);
		}
	}
}
