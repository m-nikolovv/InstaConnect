namespace InstaConnect.Identity.Presentation.Tests.Features.ForgotPasswordTokens.Assertions;

public static class ForgotPasswordTokenValidationProblemDetailsAssertions
{
	extension(ApplicationProblemDetails problemDetails)
	{
		public void ShouldSatisfyInvalidValidationForName(
			AddForgotPasswordTokenApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.Name,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForId(
			VerifyForgotPasswordTokenApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.Id,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForValue(
			VerifyForgotPasswordTokenApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.Value,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForPassword(
			VerifyForgotPasswordTokenApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.Body.Password,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForConfirmPassword(
			VerifyForgotPasswordTokenApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.Body.ConfirmPassword,
				messageTransformer);
		}
	}
}
