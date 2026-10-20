namespace InstaConnect.Identity.Application.Tests.Features.ForgotPasswordTokens.Assertions;

public static class ForgotPasswordTokenExceptionAssertions
{
	extension(IApplicationSender sender)
	{
		public async Task ShouldThrowUserNameNotFoundExceptionAsync(
			AddForgotPasswordTokenCommandRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowUserNameNotFoundExceptionAsync(
				request,
				r => r.Name,
				cancellationToken);
		}

		public async Task ShouldThrowUserNotFoundExceptionAsync(
			VerifyForgotPasswordTokenCommandRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				request,
				r => r.Id,
				cancellationToken);
		}

		public async Task ShouldThrowForgotPasswordTokenNotFoundExceptionAsync(
			VerifyForgotPasswordTokenCommandRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowForgotPasswordTokenNotFoundExceptionAsync(
				request,
				r => r.Id,
				r => r.Value,
				cancellationToken);
		}

		public async Task ShouldThrowForgotPasswordTokenExpiredExceptionAsync(
			VerifyForgotPasswordTokenCommandRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowForgotPasswordTokenExpiredExceptionAsync(
				request,
				r => r.Id,
				r => r.Value,
				cancellationToken);
		}
	}
}
