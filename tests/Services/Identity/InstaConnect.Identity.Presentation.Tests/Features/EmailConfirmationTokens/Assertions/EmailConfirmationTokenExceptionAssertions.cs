using InstaConnect.Identity.Presentation.Features.EmailConfirmationTokens.Controllers.v1;

namespace InstaConnect.Identity.Presentation.Tests.Features.EmailConfirmationTokens.Assertions;

public static class EmailConfirmationTokenExceptionAssertions
{
	extension(EmailConfirmationTokenController controller)
	{
		public async Task ShouldThrowUserNameNotFoundExceptionAsync(
			AddEmailConfirmationTokenApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.AddAsync(request, cancellationToken);

			await func.ShouldThrowUserNameNotFoundExceptionAsync(
				request,
				r => r.Name,
				cancellationToken);
		}

		public async Task ShouldThrowUserNameEmailAlreadyConfirmedExceptionAsync(
			AddEmailConfirmationTokenApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.AddAsync(request, cancellationToken);

			await func.ShouldThrowUserNameEmailAlreadyConfirmedExceptionAsync(
				request,
				r => r.Name,
				cancellationToken);
		}

		public async Task ShouldThrowUserNotFoundExceptionAsync(
			VerifyEmailConfirmationTokenApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.VerifyAsync(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				request,
				r => r.Id,
				cancellationToken);
		}

		public async Task ShouldThrowUserEmailAlreadyConfirmedExceptionAsync(
			VerifyEmailConfirmationTokenApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.VerifyAsync(request, cancellationToken);

			await func.ShouldThrowUserEmailAlreadyConfirmedExceptionAsync(
				request,
				r => r.Id,
				cancellationToken);
		}

		public async Task ShouldThrowEmailConfirmationTokenNotFoundExceptionAsync(
			VerifyEmailConfirmationTokenApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.VerifyAsync(request, cancellationToken);

			await func.ShouldThrowEmailConfirmationTokenNotFoundExceptionAsync(
				request,
				r => r.Id,
				r => r.Value,
				cancellationToken);
		}

		public async Task ShouldThrowEmailConfirmationTokenExpiredExceptionAsync(
			VerifyEmailConfirmationTokenApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.VerifyAsync(request, cancellationToken);

			await func.ShouldThrowEmailConfirmationTokenExpiredExceptionAsync(
				request,
				r => r.Id,
				r => r.Value,
				cancellationToken);
		}
	}
}
