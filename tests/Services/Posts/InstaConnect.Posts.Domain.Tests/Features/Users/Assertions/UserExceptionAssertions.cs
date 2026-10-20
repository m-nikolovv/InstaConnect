namespace InstaConnect.Posts.Domain.Tests.Features.Users.Assertions;

public static class UserExceptionAssertions
{
	extension(IUserCommandService service)
	{
		public async Task ShouldThrowUserNotFoundExceptionAsync(
		UpdateUserCommand request,
		CancellationToken cancellationToken)
		{
			var action = () => service.UpdateAsync(request, cancellationToken);

			await action.ShouldThrowUserNotFoundExceptionAsync(
				request,
				r => r.Id,
				cancellationToken);
		}

		public async Task ShouldThrowUserNotFoundExceptionAsync(
			DeleteUserCommand request,
			CancellationToken cancellationToken)
		{
			var action = () => service.DeleteAsync(request, cancellationToken);

			await action.ShouldThrowUserNotFoundExceptionAsync(
				request,
				r => r.Id,
				cancellationToken);
		}

		public async Task ShouldThrowUserAlreadyExistsExceptionAsync(
			AddUserCommand request,
			CancellationToken cancellationToken)
		{
			var action = () => service.AddAsync(request, cancellationToken);

			await action.ShouldThrowUserAlreadyExistsExceptionAsync(
				request,
				r => r.Id,
				cancellationToken);
		}

		public async Task ShouldThrowUserNameAlreadyExistsExceptionAsync(
			AddUserCommand request,
			CancellationToken cancellationToken)
		{
			var action = () => service.AddAsync(request, cancellationToken);

			await action.ShouldThrowUserNameAlreadyExistsExceptionAsync(
				request,
				r => r.Name,
				cancellationToken);
		}

		public async Task ShouldThrowUserNameAlreadyExistsExceptionAsync(
			UpdateUserCommand request,
			CancellationToken cancellationToken)
		{
			var action = () => service.UpdateAsync(request, cancellationToken);

			await action.ShouldThrowUserNameAlreadyExistsExceptionAsync(
				request,
				r => r.Name,
				cancellationToken);
		}

		public async Task ShouldThrowUserEmailAlreadyExistsExceptionAsync(
			AddUserCommand request,
			CancellationToken cancellationToken)
		{
			var action = () => service.AddAsync(request, cancellationToken);

			await action.ShouldThrowUserEmailAlreadyExistsExceptionAsync(
				request,
				r => r.Email,
				cancellationToken);
		}

		public async Task ShouldThrowUserEmailAlreadyExistsExceptionAsync(
			UpdateUserCommand request,
			CancellationToken cancellationToken)
		{
			var action = () => service.UpdateAsync(request, cancellationToken);

			await action.ShouldThrowUserEmailAlreadyExistsExceptionAsync(
				request,
				r => r.Email,
				cancellationToken);
		}
	}
}
