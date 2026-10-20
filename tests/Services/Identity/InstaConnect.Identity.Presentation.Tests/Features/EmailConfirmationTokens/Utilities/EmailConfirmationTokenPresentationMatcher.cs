using InstaConnect.Identity.Application.Features.EmailConfirmationTokens.Commands.Add;
using InstaConnect.Identity.Application.Features.EmailConfirmationTokens.Commands.Verify;

namespace InstaConnect.Identity.Presentation.Tests.Features.EmailConfirmationTokens.Utilities;

public static class EmailConfirmationTokenPresentationMatcher
{
	extension(AddEmailConfirmationTokenApiRequest request)
	{
		public AddEmailConfirmationTokenCommandRequest IsAddEmailConfirmationTokenCommandRequest()
		{
			return Matcher.Is<AddEmailConfirmationTokenCommandRequest>(p => p.Matches(request));
		}
	}

	extension(VerifyEmailConfirmationTokenApiRequest request)
	{
		public VerifyEmailConfirmationTokenCommandRequest IsVerifyEmailConfirmationTokenCommandRequest()
		{
			return Matcher.Is<VerifyEmailConfirmationTokenCommandRequest>(p => p.Matches(request));
		}
	}
}
