using InstaConnect.Follows.Tests.Features.Users.Assertions;

namespace InstaConnect.Follows.Application.Tests.Features.Users.Assertions;

public static class UserExceptionAssertions
{
	extension(IApplicationSender sender)
	{
		public async Task ShouldThrowUserNotFoundExceptionAsync(
		UpdateUserCommandRequest request,
		CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				request,
				r => r.Id,
				cancellationToken);
		}

		public async Task ShouldThrowUserNotFoundExceptionAsync(
			DeleteUserCommandRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				request,
				r => r.Id,
				cancellationToken);
		}

		public async Task ShouldThrowUserAlreadyExistsExceptionAsync(
			AddUserCommandRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowUserAlreadyExistsExceptionAsync(
				request,
				r => r.Id,
				cancellationToken);
		}

		public async Task ShouldThrowUserNameAlreadyExistsExceptionAsync(
			AddUserCommandRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowUserNameAlreadyExistsExceptionAsync(
				request,
				r => r.Name,
				cancellationToken);
		}

		public async Task ShouldThrowUserNameAlreadyExistsExceptionAsync(
			UpdateUserCommandRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowUserNameAlreadyExistsExceptionAsync(
				request,
				r => r.Name,
				cancellationToken);
		}

		public async Task ShouldThrowUserEmailAlreadyExistsExceptionAsync(
			AddUserCommandRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowUserEmailAlreadyExistsExceptionAsync(
				request,
				r => r.Email,
				cancellationToken);
		}

		public async Task ShouldThrowUserEmailAlreadyExistsExceptionAsync(
			UpdateUserCommandRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowUserEmailAlreadyExistsExceptionAsync(
				request,
				r => r.Email,
				cancellationToken);
		}
	}
}
