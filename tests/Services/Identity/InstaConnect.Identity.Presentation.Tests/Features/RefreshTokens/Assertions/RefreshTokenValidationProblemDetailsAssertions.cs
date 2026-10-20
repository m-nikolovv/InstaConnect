namespace InstaConnect.Identity.Presentation.Tests.Features.RefreshTokens.Assertions;

public static class RefreshTokenValidationProblemDetailsAssertions
{
	extension(ApplicationProblemDetails problemDetails)
	{
		public void ShouldSatisfyInvalidValidationForName(
			IssueRefreshTokenApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.Name,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForPassword(
			IssueRefreshTokenApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.Body.Password,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForId(
			DeleteCurrentRefreshTokenApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.Id,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForId(
			RotateRefreshTokenApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.Id,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForValue(
			DeleteCurrentRefreshTokenApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.Value,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForValue(
			RotateRefreshTokenApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.Value,
				messageTransformer);
		}
	}
}
