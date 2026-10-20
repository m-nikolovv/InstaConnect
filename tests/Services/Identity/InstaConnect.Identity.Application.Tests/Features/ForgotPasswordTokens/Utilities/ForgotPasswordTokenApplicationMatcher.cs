using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Requests;

namespace InstaConnect.Identity.Application.Tests.Features.ForgotPasswordTokens.Utilities;

public static class ForgotPasswordTokenApplicationMatcher
{
	extension(AddForgotPasswordTokenCommandRequest request)
	{
		public AddForgotPasswordTokenCommand IsAddForgotPasswordTokenCommand()
		{
			return Matcher.Is<AddForgotPasswordTokenCommand>(p => p.Matches(request));
		}
	}

	extension(VerifyForgotPasswordTokenCommandRequest request)
	{
		public VerifyForgotPasswordTokenCommand IsVerifyForgotPasswordTokenCommand()
		{
			return Matcher.Is<VerifyForgotPasswordTokenCommand>(p => p.Matches(request));
		}
	}
}
