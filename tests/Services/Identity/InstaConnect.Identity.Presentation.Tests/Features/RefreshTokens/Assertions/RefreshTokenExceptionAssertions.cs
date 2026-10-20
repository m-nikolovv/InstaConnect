using InstaConnect.Identity.Presentation.Features.RefreshTokens.Controllers.v1;

namespace InstaConnect.Identity.Presentation.Tests.Features.RefreshTokens.Assertions;

public static class RefreshTokenExceptionAssertions
{
	extension(RefreshTokenController controller)
	{
		public async Task ShouldThrowUserInvalidDetailsExceptionAsync(
			IssueRefreshTokenApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.IssueAsync(request, cancellationToken);

			await func.ShouldThrowUserInvalidDetailsExceptionAsync(
				request,
				r => r.Name,
				cancellationToken);
		}

		public async Task ShouldThrowUserNameEmailNotConfirmedExceptionAsync(
			IssueRefreshTokenApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.IssueAsync(request, cancellationToken);

			await func.ShouldThrowUserNameEmailNotConfirmedExceptionAsync(
				request,
				r => r.Name,
				cancellationToken);
		}

		public async Task ShouldThrowUserEmailNotConfirmedExceptionAsync(
			RotateRefreshTokenApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.RotateAsync(request, cancellationToken);

			await func.ShouldThrowUserEmailNotConfirmedExceptionAsync(
				request,
				r => r.Id,
				cancellationToken);
		}

		public async Task ShouldThrowUserNotFoundExceptionAsync(
			RotateRefreshTokenApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.RotateAsync(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				request,
				r => r.Id,
				cancellationToken);
		}

		public async Task ShouldThrowUserNotFoundExceptionAsync(
			DeleteCurrentRefreshTokenApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.DeleteCurrentAsync(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				request,
				r => r.Id,
				cancellationToken);
		}

		public async Task ShouldThrowRefreshTokenNotFoundExceptionAsync(
			RotateRefreshTokenApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.RotateAsync(request, cancellationToken);

			await func.ShouldThrowRefreshTokenNotFoundExceptionAsync(
				request,
				r => r.Id,
				r => r.Value,
				cancellationToken);
		}

		public async Task ShouldThrowRefreshTokenNotFoundExceptionAsync(
			DeleteCurrentRefreshTokenApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.DeleteCurrentAsync(request, cancellationToken);

			await func.ShouldThrowRefreshTokenNotFoundExceptionAsync(
				request,
				r => r.Id,
				r => r.Value,
				cancellationToken);
		}

		public async Task ShouldThrowRefreshTokenExpiredExceptionAsync(
			RotateRefreshTokenApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.RotateAsync(request, cancellationToken);

			await func.ShouldThrowRefreshTokenExpiredExceptionAsync(
				request,
				r => r.Id,
				r => r.Value,
				cancellationToken);
		}
	}
}
