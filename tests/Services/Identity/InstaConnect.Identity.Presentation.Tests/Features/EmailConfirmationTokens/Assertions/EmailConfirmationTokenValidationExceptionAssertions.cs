using InstaConnect.Identity.Presentation.Features.EmailConfirmationTokens.Controllers.v1;

namespace InstaConnect.Identity.Presentation.Tests.Features.EmailConfirmationTokens.Assertions;

public static class EmailConfirmationTokenValidationExceptionAssertions
{
	extension(EmailConfirmationTokenController controller)
	{
		public async Task ShouldThrowInvalidValidationExceptionForNameAsync(
			AddEmailConfirmationTokenApiRequest request,
			IStringMessageTransformer messageTransformer,
			CancellationToken cancellationToken)
		{
			var func = () => controller.AddAsync(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(
				request,
				p => p.Name,
				messageTransformer,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForIdAsync(
			VerifyEmailConfirmationTokenApiRequest request,
			IStringMessageTransformer messageTransformer,
			CancellationToken cancellationToken)
		{
			var func = () => controller.VerifyAsync(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(
				request,
				p => p.Id,
				messageTransformer,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForValueAsync(
			VerifyEmailConfirmationTokenApiRequest request,
			IStringMessageTransformer messageTransformer,
			CancellationToken cancellationToken)
		{
			var func = () => controller.VerifyAsync(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(
				request,
				p => p.Value,
				messageTransformer,
				cancellationToken);
		}
	}
}
