using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Assertions;
using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Utilities;
using InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Assertions;
using InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Utilities;

namespace InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Assertions;

public static class ForgotPasswordTokenMatchAssertions
{
	extension(ForgotPasswordToken u)
	{
		public void ShouldSatisfy(ForgotPasswordToken forgotPasswordToken)
		{
			u.ShouldSatisfy(u => u.Matches(forgotPasswordToken));
		}
	}

	extension(ICollection<ForgotPasswordToken> u)
	{
		public void ShouldSatisfy(ICollection<ForgotPasswordToken> forgotPasswordTokens)
		{
			u.ShouldSatisfy(u => u.Matches(forgotPasswordTokens));
		}
	}
}
