namespace InstaConnect.Identity.Domain.Tests.Features.EmailConfirmationTokens.Utilities;

public static class EmailConfirmationTokenDomainMatcher
{
	extension(VerifyEmailConfirmationTokenCommand command)
	{
		public User IsUser()
		{
			return Matcher.Is<User>(p => p.Matches(command));
		}

		public ICollection<EmailConfirmationToken> IsEmailConfirmationTokenCollection()
		{
			return Matcher.Is<ICollection<EmailConfirmationToken>>(p => p.Matches(command));
		}

		public ICollection<EmailConfirmationTokenDeletedEventRequest> IsEmailConfirmationTokenDeletedEventRequestCollection(ICollection<EmailConfirmationToken> emailConfirmationTokens)
		{
			return Matcher.Is<ICollection<EmailConfirmationTokenDeletedEventRequest>>(p => p.Matches(command, emailConfirmationTokens));
		}
	}

	extension(AddEmailConfirmationTokenCommand command)
	{
		public EmailConfirmationToken IsEmailConfirmationToken()
		{
			return Matcher.Is<EmailConfirmationToken>(p => p.Matches(command));
		}

		public EmailConfirmationTokenAddedEventRequest IsEmailConfirmationTokenAddedEventRequest(EmailConfirmationToken emailConfirmationToken)
		{
			return Matcher.Is<EmailConfirmationTokenAddedEventRequest>(p => p.Matches(command, emailConfirmationToken));
		}
	}
}
