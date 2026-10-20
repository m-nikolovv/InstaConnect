using InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Assertions;

namespace InstaConnect.Identity.Domain.Tests.Features.ForgotPasswordTokens.Assertions;

public static class ForgotPasswordTokenExceptionAssertions
{
	extension(IForgotPasswordTokenCommandService service)
	{
		public async Task ShouldThrowUserNameNotFoundExceptionAsync(
			AddForgotPasswordTokenCommand command,
			CancellationToken cancellationToken)
		{
			var func = () => service.AddAsync(command, cancellationToken);

			await func.ShouldThrowUserNameNotFoundExceptionAsync(
				command,
				r => r.Name,
				cancellationToken);
		}

		public async Task ShouldThrowUserNotFoundExceptionAsync(
			VerifyForgotPasswordTokenCommand command,
			CancellationToken cancellationToken)
		{
			var func = () => service.VerifyAsync(command, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				command,
				r => r.Id.Id,
				cancellationToken);
		}

		public async Task ShouldThrowForgotPasswordTokenNotFoundExceptionAsync(
			VerifyForgotPasswordTokenCommand command,
			CancellationToken cancellationToken)
		{
			var func = () => service.VerifyAsync(command, cancellationToken);

			await func.ShouldThrowForgotPasswordTokenNotFoundExceptionAsync(
				command,
				r => r.Id,
				cancellationToken);
		}

		public async Task ShouldThrowForgotPasswordTokenExpiredExceptionAsync(
			VerifyForgotPasswordTokenCommand command,
			CancellationToken cancellationToken)
		{
			var func = () => service.VerifyAsync(command, cancellationToken);

			await func.ShouldThrowForgotPasswordTokenExpiredExceptionAsync(
				command,
				r => r.Id,
				cancellationToken);
		}
	}
}
