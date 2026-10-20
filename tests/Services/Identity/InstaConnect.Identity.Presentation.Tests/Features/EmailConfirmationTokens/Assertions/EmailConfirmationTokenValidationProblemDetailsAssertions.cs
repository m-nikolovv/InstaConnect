namespace InstaConnect.Identity.Presentation.Tests.Features.EmailConfirmationTokens.Assertions;

public static class EmailConfirmationTokenValidationProblemDetailsAssertions
{
	extension(ApplicationProblemDetails problemDetails)
	{
		public void ShouldSatisfyInvalidValidationForName(
			AddEmailConfirmationTokenApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.Name,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForId(
			VerifyEmailConfirmationTokenApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.Id,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForValue(
			VerifyEmailConfirmationTokenApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.Value,
				messageTransformer);
		}
	}
}
