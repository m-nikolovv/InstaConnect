using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Assertions;

namespace InstaConnect.Identity.Domain.Tests.Features.EmailConfirmationTokens.Assertions;

public static class EmailConfirmationTokenExceptionAssertions
{
	extension(IEmailConfirmationTokenCommandService service)
	{
		public async Task ShouldThrowUserNameNotFoundExceptionAsync(
			AddEmailConfirmationTokenCommand command,
			CancellationToken cancellationToken)
		{
			var func = () => service.AddAsync(command, cancellationToken);

			await func.ShouldThrowUserNameNotFoundExceptionAsync(
				command,
				r => r.Name,
				cancellationToken);
		}

		public async Task ShouldThrowUserNameEmailAlreadyConfirmedExceptionAsync(
			AddEmailConfirmationTokenCommand command,
			CancellationToken cancellationToken)
		{
			var func = () => service.AddAsync(command, cancellationToken);

			await func.ShouldThrowUserNameEmailAlreadyConfirmedExceptionAsync(
				command,
				r => r.Name,
				cancellationToken);
		}

		public async Task ShouldThrowUserNotFoundExceptionAsync(
			VerifyEmailConfirmationTokenCommand command,
			CancellationToken cancellationToken)
		{
			var func = () => service.VerifyAsync(command, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				command,
				r => r.Id.Id,
				cancellationToken);
		}

		public async Task ShouldThrowUserEmailAlreadyConfirmedExceptionAsync(
			VerifyEmailConfirmationTokenCommand command,
			CancellationToken cancellationToken)
		{
			var func = () => service.VerifyAsync(command, cancellationToken);

			await func.ShouldThrowUserEmailAlreadyConfirmedExceptionAsync(
				command,
				r => r.Id.Id,
				cancellationToken);
		}

		public async Task ShouldThrowEmailConfirmationTokenNotFoundExceptionAsync(
			VerifyEmailConfirmationTokenCommand command,
			CancellationToken cancellationToken)
		{
			var func = () => service.VerifyAsync(command, cancellationToken);

			await func.ShouldThrowEmailConfirmationTokenNotFoundExceptionAsync(
				command,
				r => r.Id,
				cancellationToken);
		}

		public async Task ShouldThrowEmailConfirmationTokenExpiredExceptionAsync(
			VerifyEmailConfirmationTokenCommand command,
			CancellationToken cancellationToken)
		{
			var func = () => service.VerifyAsync(command, cancellationToken);

			await func.ShouldThrowEmailConfirmationTokenExpiredExceptionAsync(
				command,
				r => r.Id,
				cancellationToken);
		}
	}
}
