using InstaConnect.Identity.Presentation.Features.RefreshTokens.Controllers.v1;

namespace InstaConnect.Identity.Presentation.Tests.Features.RefreshTokens.Assertions;

public static class RefreshTokenValidationExceptionAssertions
{
	extension(RefreshTokenController controller)
	{
		public async Task ShouldThrowInvalidValidationExceptionForNameAsync(
			IssueRefreshTokenApiRequest request,
			IStringMessageTransformer messageTransformer,
			CancellationToken cancellationToken)
		{
			var func = () => controller.IssueAsync(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(
				request,
				p => p.Name,
				messageTransformer,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForPasswordAsync(
			IssueRefreshTokenApiRequest request,
			IStringMessageTransformer messageTransformer,
			CancellationToken cancellationToken)
		{
			var func = () => controller.IssueAsync(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(
				request,
				p => p.Body.Password,
				messageTransformer,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForIdAsync(
			RotateRefreshTokenApiRequest request,
			IStringMessageTransformer messageTransformer,
			CancellationToken cancellationToken)
		{
			var func = () => controller.RotateAsync(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(
				request,
				p => p.Id,
				messageTransformer,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForIdAsync(
			DeleteCurrentRefreshTokenApiRequest request,
			IStringMessageTransformer messageTransformer,
			CancellationToken cancellationToken)
		{
			var func = () => controller.DeleteCurrentAsync(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(
				request,
				p => p.Id,
				messageTransformer,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForValueAsync(
			RotateRefreshTokenApiRequest request,
			IStringMessageTransformer messageTransformer,
			CancellationToken cancellationToken)
		{
			var func = () => controller.RotateAsync(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(
				request,
				p => p.Value,
				messageTransformer,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForValueAsync(
			DeleteCurrentRefreshTokenApiRequest request,
			IStringMessageTransformer messageTransformer,
			CancellationToken cancellationToken)
		{
			var func = () => controller.DeleteCurrentAsync(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(
				request,
				p => p.Value,
				messageTransformer,
				cancellationToken);
		}
	}
}
