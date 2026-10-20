namespace InstaConnect.Identity.Domain.Tests.Features.Users.Utilities;

public static class UserDomainMatcher
{
	extension(UpdateUserCommand command)
	{
		public User IsUser()
		{
			return Matcher.Is<User>(p => p.Matches(command));
		}

		public UserUpdatedEventRequest IsUserUpdatedEventRequest(User user)
		{
			return Matcher.Is<UserUpdatedEventRequest>(p => p.Matches(command, user));
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

	extension(AddUserCommand command)
	{
		public User IsUser()
		{
			return Matcher.Is<User>(p => p.Matches(command));
		}

		public UserAddedEventRequest IsUserAddedEventRequest(User user)
		{
			return Matcher.Is<UserAddedEventRequest>(p => p.Matches(command, user));
		}

		public EmailConfirmationToken IsEmailConfirmationToken()
		{
			return Matcher.Is<EmailConfirmationToken>(p => p.Matches(command));
		}

		public EmailConfirmationTokenAddedEventRequest IsEmailConfirmationTokenAddedEventRequest(EmailConfirmationToken emailConfirmationToken)
		{
			return Matcher.Is<EmailConfirmationTokenAddedEventRequest>(p => p.Matches(command, emailConfirmationToken));
		}
	}

	extension(DeleteUserCommand command)
	{
		public User IsUser()
		{
			return Matcher.Is<User>(p => p.Matches(command));
		}

		public UserDeletedEventRequest IsUserDeletedEventRequest(User user)
		{
			return Matcher.Is<UserDeletedEventRequest>(p => p.Matches(command, user));
		}
	}
}
