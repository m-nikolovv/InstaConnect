using InstaConnect.Common.Domain.Features.AccessTokens.Models;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Responses;

namespace InstaConnect.Identity.Domain.Tests.Features.RefreshTokens.Utilities;

public static class RefreshTokenMapper
{
	extension(RefreshToken refreshToken)
	{
		private AccessToken ToAccessToken()
		{
			return new(refreshToken.Id.Value, refreshToken.ExpiresAtUtc);
		}

		internal SessionToken ToSessionTokenResponse()
		{
			return new(refreshToken.Id, refreshToken.ToAccessToken(), refreshToken.ExpiresAtUtc);
		}

		public SessionToken ToResponse(IssueRefreshTokenCommand command)
		{
			return refreshToken.ToSessionTokenResponse();
		}

		public SessionToken ToResponse(RotateRefreshTokenCommand command)
		{
			return refreshToken.ToSessionTokenResponse();
		}
	}
}
