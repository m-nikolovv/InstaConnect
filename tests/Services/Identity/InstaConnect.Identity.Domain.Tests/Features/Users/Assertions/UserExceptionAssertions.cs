namespace InstaConnect.Identity.Domain.Tests.Features.Users.Assertions;

public static class UserExceptionAssertions
{
	extension(IUserCommandService service)
	{
		public async Task ShouldThrowUserEmailAlreadyTakenExceptionAsync(
			AddUserCommand request,
			CancellationToken cancellationToken)
		{
			var func = () => service.AddAsync(request, cancellationToken);

			await func.ShouldThrowUserEmailAlreadyTakenExceptionAsync(
				request,
				r => r.Email,
				cancellationToken);
		}

		public async Task ShouldThrowUserEmailAlreadyTakenExceptionAsync(
			UpdateUserCommand request,
			CancellationToken cancellationToken)
		{
			var func = () => service.UpdateAsync(request, cancellationToken);

			await func.ShouldThrowUserEmailAlreadyTakenExceptionAsync(
				request,
				r => r.Email,
				cancellationToken);
		}

		public async Task ShouldThrowUserNameAlreadyTakenExceptionAsync(
			AddUserCommand request,
			CancellationToken cancellationToken)
		{
			var func = () => service.AddAsync(request, cancellationToken);

			await func.ShouldThrowUserNameAlreadyTakenExceptionAsync(
				request,
				r => r.Name,
				cancellationToken);
		}

		public async Task ShouldThrowUserNameAlreadyTakenExceptionAsync(
			UpdateUserCommand request,
			CancellationToken cancellationToken)
		{
			var func = () => service.UpdateAsync(request, cancellationToken);

			await func.ShouldThrowUserNameAlreadyTakenExceptionAsync(
				request,
				r => r.Name,
				cancellationToken);
		}

		public async Task ShouldThrowUserNotFoundExceptionAsync(
			UpdateUserCommand request,
			CancellationToken cancellationToken)
		{
			var func = () => service.UpdateAsync(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				request,
				r => r.Id,
				cancellationToken);
		}

		public async Task ShouldThrowUserNotFoundExceptionAsync(
			DeleteUserCommand request,
			CancellationToken cancellationToken)
		{
			var func = () => service.DeleteAsync(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				request,
				r => r.Id,
				cancellationToken);
		}
	}

	extension(IUserQueryService service)
	{
		public async Task ShouldThrowUserNotFoundExceptionAsync(
			GetUserByIdQuery request,
			CancellationToken cancellationToken)
		{
			var func = () => service.GetByIdAsync(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				request,
				r => r.Id,
				cancellationToken);
		}
	}
}
