using InstaConnect.Identity.Domain.Features.Common.Helpers;
using InstaConnect.Identity.Domain.Tests.Features.ForgotPasswordTokens.Utilities;
using InstaConnect.Identity.Events.Features.ForgotPasswordTokens;

namespace InstaConnect.Identity.Domain.Tests.Features.ForgotPasswordTokens.Assertions;

public static class ForgotPasswordTokenMatchAssertions
{
	extension(ForgotPasswordTokenId response)
	{
		public void ShouldSatisfy(AddForgotPasswordTokenCommand command, ForgotPasswordToken forgotPasswordToken)
		{
			response.ShouldSatisfy(p => p.Matches(command, forgotPasswordToken));
		}
	}

	extension(User user)
	{
		public void ShouldSatisfy(VerifyForgotPasswordTokenCommand command, IPasswordHasher passwordHasher)
		{
			user.ShouldSatisfy(p => p.Matches(command, passwordHasher));
		}
	}

	extension(ICollection<ForgotPasswordToken> forgotPasswordTokens)
	{
		public void ShouldSatisfy(AddForgotPasswordTokenCommand command)
		{
			forgotPasswordTokens.ShouldSatisfy(p => p.Matches(command));
		}
	}

	extension(ICollection<ForgotPasswordTokenAddedEventRequest> r)
	{
		public void ShouldSatisfy(AddForgotPasswordTokenCommand command, ICollection<ForgotPasswordToken> entities)
		{
			r.ShouldSatisfy(r => r.Matches(command, entities));
		}
	}

	extension(ICollection<ForgotPasswordTokenDeletedEventRequest> r)
	{
		public void ShouldSatisfy(VerifyForgotPasswordTokenCommand command, ICollection<ForgotPasswordToken> entities)
		{
			r.ShouldSatisfy(r => r.Matches(command, entities));
		}
	}
}
