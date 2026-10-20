using InstaConnect.Common.Application.Features.AccessTokens.Models;
using InstaConnect.Identity.Application.Features.RefreshTokens.Commands.Issue;
using InstaConnect.Identity.Application.Features.RefreshTokens.Commands.Rotate;
using InstaConnect.Identity.Application.Features.RefreshTokens.Models;

namespace InstaConnect.Identity.Presentation.Tests.Features.RefreshTokens.Utilities;

public static class RefreshTokenMapper
{
	extension(RefreshToken refreshToken)
	{
		private AccessTokenCommandResponse ToResponse()
		{
			return new(refreshToken.Id.Value, refreshToken.ExpiresAtUtc);
		}

		internal RefreshTokenIdCommandResponse ToIdResponse()
		{
			return new(refreshToken.Id.Id.Id, refreshToken.Id.Value);
		}

		internal SessionTokenCommandResponse ToSessionTokenResponse()
		{
			return new(
				refreshToken.ToIdResponse(),
				refreshToken.ToResponse(),
				refreshToken.ExpiresAtUtc);
		}

		public IssueRefreshTokenCommandResponse ToResponse(IssueRefreshTokenApiRequest request)
		{
			return new(refreshToken.ToSessionTokenResponse());
		}

		public RotateRefreshTokenCommandResponse ToResponse(RotateRefreshTokenApiRequest request)
		{
			return new(refreshToken.ToSessionTokenResponse());
		}
	}
}
