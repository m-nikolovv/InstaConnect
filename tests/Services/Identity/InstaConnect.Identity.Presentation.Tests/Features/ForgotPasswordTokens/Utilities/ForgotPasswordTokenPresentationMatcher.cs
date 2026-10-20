using InstaConnect.Identity.Application.Features.ForgotPasswordTokens.Commands.Add;
using InstaConnect.Identity.Application.Features.ForgotPasswordTokens.Commands.Verify;

namespace InstaConnect.Identity.Presentation.Tests.Features.ForgotPasswordTokens.Utilities;

public static class ForgotPasswordTokenPresentationMatcher
{
	extension(AddForgotPasswordTokenApiRequest request)
	{
		public AddForgotPasswordTokenCommandRequest IsAddForgotPasswordTokenCommandRequest()
		{
			return Matcher.Is<AddForgotPasswordTokenCommandRequest>(p => p.Matches(request));
		}
	}

	extension(VerifyForgotPasswordTokenApiRequest request)
	{
		public VerifyForgotPasswordTokenCommandRequest IsVerifyForgotPasswordTokenCommandRequest()
		{
			return Matcher.Is<VerifyForgotPasswordTokenCommandRequest>(p => p.Matches(request));
		}
	}
}
