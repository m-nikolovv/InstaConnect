using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Entities;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.ValueObjects;
using InstaConnect.Identity.Infrastructure.Tests.Features.RefreshTokens.Utilities;

namespace InstaConnect.Identity.Infrastructure.Tests.Features.RefreshTokens.Assertions;

public static class RefreshTokenMatchAssertions
{
	extension(RefreshToken response)
	{
		public void ShouldSatisfy(RefreshTokenId id, RefreshToken refreshToken)
		{
			response.ShouldSatisfy(p => p.Matches(id, refreshToken));
		}
	}

	extension(ICollection<RefreshToken> response)
	{
		public void ShouldSatisfy(ICollection<RefreshTokenId> ids, ICollection<RefreshToken> refreshTokens)
		{
			response.ShouldSatisfy(p => p.Matches(ids, refreshTokens));
		}
	}
}
