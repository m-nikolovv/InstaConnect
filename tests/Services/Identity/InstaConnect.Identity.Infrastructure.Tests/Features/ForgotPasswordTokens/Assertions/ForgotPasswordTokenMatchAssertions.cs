using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Entities;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.ValueObjects;
using InstaConnect.Identity.Infrastructure.Tests.Features.ForgotPasswordTokens.Utilities;

namespace InstaConnect.Identity.Infrastructure.Tests.Features.ForgotPasswordTokens.Assertions;

public static class ForgotPasswordTokenMatchAssertions
{
	extension(ForgotPasswordToken response)
	{
		public void ShouldSatisfy(ForgotPasswordTokenId id, ForgotPasswordToken forgotPasswordToken)
		{
			response.ShouldSatisfy(p => p.Matches(id, forgotPasswordToken));
		}
	}

	extension(ICollection<ForgotPasswordToken> response)
	{
		public void ShouldSatisfy(ICollection<ForgotPasswordTokenId> ids, ICollection<ForgotPasswordToken> forgotPasswordTokens)
		{
			response.ShouldSatisfy(p => p.Matches(ids, forgotPasswordTokens));
		}
	}

	extension(bool response)
	{
		public void ShouldSatisfy(ForgotPasswordTokenId id, ForgotPasswordToken? forgotPasswordToken)
		{
			response.ShouldSatisfy(p => p.Matches(id, forgotPasswordToken));
		}
	}
}
