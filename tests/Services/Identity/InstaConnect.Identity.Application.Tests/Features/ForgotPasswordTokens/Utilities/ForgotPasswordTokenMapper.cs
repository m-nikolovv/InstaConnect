using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.ValueObjects;

namespace InstaConnect.Identity.Application.Tests.Features.ForgotPasswordTokens.Utilities;

public static class ForgotPasswordTokenMapper
{
	extension(ForgotPasswordToken forgotPasswordToken)
	{
		public ForgotPasswordTokenId ToResponse(
			AddForgotPasswordTokenCommandRequest request)
		{
			return forgotPasswordToken.ToId();
		}
	}
}
