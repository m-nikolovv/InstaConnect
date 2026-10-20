using InstaConnect.Identity.Tests.Features.RefreshTokens.Assertions;

namespace InstaConnect.Identity.Domain.Tests.Features.RefreshTokens.Assertions;

public static class RefreshTokenExceptionAssertions
{
	extension(IRefreshTokenCommandService service)
	{
		public async Task ShouldThrowUserInvalidDetailsExceptionAsync(
			IssueRefreshTokenCommand command,
			CancellationToken cancellationToken)
		{
			var func = () => service.IssueAsync(command, cancellationToken);

			await func.ShouldThrowUserInvalidDetailsExceptionAsync(
				command,
				r => r.Name,
				cancellationToken);
		}

		public async Task ShouldThrowUserNameEmailNotConfirmedExceptionAsync(
			IssueRefreshTokenCommand command,
			CancellationToken cancellationToken)
		{
			var func = () => service.IssueAsync(command, cancellationToken);

			await func.ShouldThrowUserNameEmailNotConfirmedExceptionAsync(
				command,
				r => r.Name,
				cancellationToken);
		}

		public async Task ShouldThrowUserNotFoundExceptionAsync(
			RotateRefreshTokenCommand command,
			CancellationToken cancellationToken)
		{
			var func = () => service.RotateAsync(command, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				command,
				r => r.Id.Id,
				cancellationToken);
		}

		public async Task ShouldThrowUserNotFoundExceptionAsync(
			DeleteRefreshTokenCommand command,
			CancellationToken cancellationToken)
		{
			var func = () => service.DeleteAsync(command, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				command,
				r => r.Id.Id,
				cancellationToken);
		}

		public async Task ShouldThrowUserEmailNotConfirmedExceptionAsync(
			RotateRefreshTokenCommand command,
			CancellationToken cancellationToken)
		{
			var func = () => service.RotateAsync(command, cancellationToken);

			await func.ShouldThrowUserEmailNotConfirmedExceptionAsync(
				command,
				r => r.Id.Id,
				cancellationToken);
		}

		public async Task ShouldThrowRefreshTokenNotFoundExceptionAsync(
			RotateRefreshTokenCommand command,
			CancellationToken cancellationToken)
		{
			var func = () => service.RotateAsync(command, cancellationToken);

			await func.ShouldThrowRefreshTokenNotFoundExceptionAsync(
				command,
				r => r.Id,
				cancellationToken);
		}

		public async Task ShouldThrowRefreshTokenNotFoundExceptionAsync(
			DeleteRefreshTokenCommand command,
			CancellationToken cancellationToken)
		{
			var func = () => service.DeleteAsync(command, cancellationToken);

			await func.ShouldThrowRefreshTokenNotFoundExceptionAsync(
				command,
				r => r.Id,
				cancellationToken);
		}

		public async Task ShouldThrowRefreshTokenExpiredExceptionAsync(
			RotateRefreshTokenCommand command,
			CancellationToken cancellationToken)
		{
			var func = () => service.RotateAsync(command, cancellationToken);

			await func.ShouldThrowRefreshTokenExpiredExceptionAsync(
				command,
				r => r.Id,
				cancellationToken);
		}
	}
}
