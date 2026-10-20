using InstaConnect.Identity.Presentation.Features.ForgotPasswordTokens.Controllers.v1;

namespace InstaConnect.Identity.Presentation.Tests.Features.ForgotPasswordTokens.Assertions;

public static class ForgotPasswordTokenExceptionAssertions
{
	extension(ForgotPasswordTokenController controller)
	{
		public async Task ShouldThrowUserNameNotFoundExceptionAsync(
			AddForgotPasswordTokenApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.AddAsync(request, cancellationToken);

			await func.ShouldThrowUserNameNotFoundExceptionAsync(
				request,
				r => r.Name,
				cancellationToken);
		}

		public async Task ShouldThrowUserNotFoundExceptionAsync(
			VerifyForgotPasswordTokenApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.VerifyAsync(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				request,
				r => r.Id,
				cancellationToken);
		}

		public async Task ShouldThrowForgotPasswordTokenNotFoundExceptionAsync(
			VerifyForgotPasswordTokenApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.VerifyAsync(request, cancellationToken);

			await func.ShouldThrowForgotPasswordTokenNotFoundExceptionAsync(
				request,
				r => r.Id,
				r => r.Value,
				cancellationToken);
		}

		public async Task ShouldThrowForgotPasswordTokenExpiredExceptionAsync(
			VerifyForgotPasswordTokenApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.VerifyAsync(request, cancellationToken);

			await func.ShouldThrowForgotPasswordTokenExpiredExceptionAsync(
				request,
				r => r.Id,
				r => r.Value,
				cancellationToken);
		}
	}
}
