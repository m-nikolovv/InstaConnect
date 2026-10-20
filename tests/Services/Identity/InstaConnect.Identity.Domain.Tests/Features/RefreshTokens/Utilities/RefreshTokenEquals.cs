using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Responses;

namespace InstaConnect.Identity.Domain.Tests.Features.RefreshTokens.Utilities;

public static class RefreshTokenEquals
{
	extension(SessionToken response)
	{
		public bool Matches(IssueRefreshTokenCommand command, RefreshToken refreshToken)
		{
			return response.Id.Matches(refreshToken.Id) &&
				   response.AccessToken.Matches() &&
				   response.ExpiresAtUtc == refreshToken.ExpiresAtUtc;
		}

		public bool Matches(RotateRefreshTokenCommand command, RefreshToken refreshToken)
		{
			return response.Id.Matches(refreshToken.Id) &&
				   response.AccessToken.Matches() &&
				   response.ExpiresAtUtc == refreshToken.ExpiresAtUtc;
		}
	}

	extension(RefreshToken refreshToken)
	{
		public bool Matches(IssueRefreshTokenCommand command)
		{
			return refreshToken.Id.Id.Id.IsNotNullOrEmptyOrWhiteSpace() &&
				   refreshToken.Id.Value.IsNotNullOrEmptyOrWhiteSpace() &&
				   refreshToken.CreatedAtUtc != default &&
				   refreshToken.ExpiresAtUtc != default;
		}

		public bool Matches(RotateRefreshTokenCommand command)
		{
			return refreshToken.Id.Id.Matches(command.Id.Id) &&
				   refreshToken.Id.Value.IsNotNullOrEmptyOrWhiteSpace() &&
				   refreshToken.CreatedAtUtc != default &&
				   refreshToken.ExpiresAtUtc != default;
		}

		public bool Matches(DeleteRefreshTokenCommand command)
		{
			return refreshToken.Id.Matches(command.Id) &&
				   refreshToken.CreatedAtUtc != default &&
				   refreshToken.ExpiresAtUtc != default;
		}
	}
}
