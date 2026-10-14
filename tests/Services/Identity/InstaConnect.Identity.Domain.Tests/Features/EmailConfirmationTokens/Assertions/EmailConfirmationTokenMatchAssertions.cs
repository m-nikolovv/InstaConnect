using InstaConnect.Identity.Domain.Tests.Features.EmailConfirmationTokens.Utilities;
using InstaConnect.Identity.Events.Features.EmailConfirmationTokens;

namespace InstaConnect.Identity.Domain.Tests.Features.EmailConfirmationTokens.Assertions;

public static class EmailConfirmationTokenMatchAssertions
{
	extension(EmailConfirmationTokenId response)
	{
		public void ShouldSatisfy(AddEmailConfirmationTokenCommand command, EmailConfirmationToken emailConfirmationToken)
		{
			response.ShouldSatisfy(p => p.Matches(command, emailConfirmationToken));
		}
	}

	extension(User user)
	{
		public void ShouldSatisfy(VerifyEmailConfirmationTokenCommand command)
		{
			user.ShouldSatisfy(p => p.Matches(command));
		}
	}

	extension(ICollection<EmailConfirmationToken> emailConfirmationTokens)
	{
		public void ShouldSatisfy(AddEmailConfirmationTokenCommand command)
		{
			emailConfirmationTokens.ShouldSatisfy(p => p.Matches(command));
		}
	}

	extension(ICollection<EmailConfirmationTokenAddedEventRequest> r)
	{
		public void ShouldSatisfy(AddEmailConfirmationTokenCommand command, ICollection<EmailConfirmationToken> entities)
		{
			r.ShouldSatisfy(r => r.Matches(command, entities));
		}
	}

	extension(ICollection<EmailConfirmationTokenDeletedEventRequest> r)
	{
		public void ShouldSatisfy(VerifyEmailConfirmationTokenCommand command, ICollection<EmailConfirmationToken> entities)
		{
			r.ShouldSatisfy(r => r.Matches(command, entities));
		}
	}
}
