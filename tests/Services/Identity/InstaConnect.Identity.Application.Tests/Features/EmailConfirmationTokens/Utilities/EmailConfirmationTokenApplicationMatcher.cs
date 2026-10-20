using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Requests;

namespace InstaConnect.Identity.Application.Tests.Features.EmailConfirmationTokens.Utilities;

public static class EmailConfirmationTokenApplicationMatcher
{
	extension(AddEmailConfirmationTokenCommandRequest request)
	{
		public AddEmailConfirmationTokenCommand IsAddEmailConfirmationTokenCommand()
		{
			return Matcher.Is<AddEmailConfirmationTokenCommand>(p => p.Matches(request));
		}
	}

	extension(VerifyEmailConfirmationTokenCommandRequest request)
	{
		public VerifyEmailConfirmationTokenCommand IsVerifyEmailConfirmationTokenCommand()
		{
			return Matcher.Is<VerifyEmailConfirmationTokenCommand>(p => p.Matches(request));
		}
	}
}
