using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Entities;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.ValueObjects;
using InstaConnect.Identity.Tests.Features.RefreshTokens.Utilities;

namespace InstaConnect.Identity.Infrastructure.Tests.Features.RefreshTokens.Utilities;

public static class RefreshTokenEquals
{
	extension(RefreshToken p)
	{
		public bool Matches(
			RefreshTokenId id,
			RefreshToken refreshToken)
		{
			return p.Matches(refreshToken);
		}
	}

	extension(ICollection<RefreshToken> p)
	{
		public bool Matches(
			ICollection<RefreshTokenId> ids,
			ICollection<RefreshToken> refreshTokens)
		{
			return p.Matches(refreshTokens);
		}
	}
}
