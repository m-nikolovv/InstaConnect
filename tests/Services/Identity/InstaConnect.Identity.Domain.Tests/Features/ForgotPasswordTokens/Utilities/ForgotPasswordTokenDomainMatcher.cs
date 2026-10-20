using InstaConnect.Identity.Events.Features.ForgotPasswordTokens;

namespace InstaConnect.Identity.Domain.Tests.Features.ForgotPasswordTokens.Utilities;

public static class ForgotPasswordTokenDomainMatcher
{
	extension(VerifyForgotPasswordTokenCommand command)
	{
		public User IsUser(IPasswordHasher passwordHasher)
		{
			return Matcher.Is<User>(p => p.Matches(command, passwordHasher));
		}

		public ICollection<ForgotPasswordToken> IsForgotPasswordTokenCollection()
		{
			return Matcher.Is<ICollection<ForgotPasswordToken>>(p => p.Matches(command));
		}

		public ICollection<ForgotPasswordTokenDeletedEventRequest> IsForgotPasswordTokenDeletedEventRequestCollection(ICollection<ForgotPasswordToken> forgotPasswordTokens)
		{
			return Matcher.Is<ICollection<ForgotPasswordTokenDeletedEventRequest>>(p => p.Matches(command, forgotPasswordTokens));
		}
	}

	extension(AddForgotPasswordTokenCommand command)
	{
		public ForgotPasswordToken IsForgotPasswordToken()
		{
			return Matcher.Is<ForgotPasswordToken>(p => p.Matches(command));
		}

		public ForgotPasswordTokenAddedEventRequest IsForgotPasswordTokenAddedEventRequest(ForgotPasswordToken forgotPasswordToken)
		{
			return Matcher.Is<ForgotPasswordTokenAddedEventRequest>(p => p.Matches(command, forgotPasswordToken));
		}
	}
}
