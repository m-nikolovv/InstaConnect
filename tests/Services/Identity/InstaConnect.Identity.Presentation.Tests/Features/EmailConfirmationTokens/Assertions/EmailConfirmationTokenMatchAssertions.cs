using InstaConnect.Identity.Events.Features.EmailConfirmationTokens;
using InstaConnect.Identity.Presentation.Tests.Features.EmailConfirmationTokens.Utilities;

namespace InstaConnect.Identity.Presentation.Tests.Features.EmailConfirmationTokens.Assertions;

public static class EmailConfirmationTokenMatchAssertions
{
	extension(User user)
	{
		public void ShouldSatisfy(VerifyEmailConfirmationTokenApiRequest request)
		{
			user.ShouldSatisfy(p => p.Matches(request));
		}
	}

	extension(ICollection<EmailConfirmationToken> emailConfirmationTokens)
	{
		public void ShouldSatisfy(AddEmailConfirmationTokenApiRequest request)
		{
			emailConfirmationTokens.ShouldSatisfy(p => p.Matches(request));
		}
	}

	extension(ICollection<EmailConfirmationTokenAddedEventRequest> r)
	{
		public void ShouldSatisfy(AddEmailConfirmationTokenApiRequest request, ICollection<EmailConfirmationToken> entities)
		{
			r.ShouldSatisfy(r => r.Matches(request, entities));
		}
	}

	extension(ICollection<EmailConfirmationTokenDeletedEventRequest> r)
	{
		public void ShouldSatisfy(VerifyEmailConfirmationTokenApiRequest request, ICollection<EmailConfirmationToken> entities)
		{
			r.ShouldSatisfy(r => r.Matches(request, entities));
		}
	}
}
