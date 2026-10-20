using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Entities;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.ValueObjects;
using InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Utilities;

namespace InstaConnect.Identity.Infrastructure.Tests.Features.ForgotPasswordTokens.Utilities;

public static class ForgotPasswordTokenEquals
{
	extension(ForgotPasswordToken p)
	{
		public bool Matches(
			ForgotPasswordTokenId id,
			ForgotPasswordToken forgotPasswordToken)
		{
			return p.Matches(forgotPasswordToken);
		}
	}

	extension(ICollection<ForgotPasswordToken> p)
	{
		public bool Matches(
			ICollection<ForgotPasswordTokenId> ids,
			ICollection<ForgotPasswordToken> forgotPasswordTokens)
		{
			return p.Matches(forgotPasswordTokens);
		}
	}

	extension(bool response)
	{
		public bool Matches(ForgotPasswordTokenId id, ForgotPasswordToken? forgotPasswordToken)
		{
			return response == (forgotPasswordToken != null);
		}
	}
}
