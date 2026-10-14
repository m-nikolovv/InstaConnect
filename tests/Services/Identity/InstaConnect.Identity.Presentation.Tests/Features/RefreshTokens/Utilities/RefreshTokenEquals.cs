using InstaConnect.Common.Domain.Features.Common.Extensions;
using InstaConnect.Common.Tests.Features.Extensions;
using InstaConnect.Identity.Presentation.Tests.Features.RefreshTokens.Models;
using InstaConnect.Identity.Presentation.Tests.Features.RefreshTokens.Utilities;
using InstaConnect.Identity.Presentation.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Presentation.Tests.Features.RefreshTokens.Utilities;


public static class RefreshTokenEquals
{
	extension(SetRefreshTokenCookieApiRequest r)
	{
		public bool Matches(IssueRefreshTokenApiRequest request, RefreshToken refreshToken)
		{
			return r.Id == refreshToken.Id.Id.Id &&
				   r.Value == refreshToken.Id.Value &&
				   r.ExpiresAtUtc == refreshToken.ExpiresAtUtc;
		}

		public bool Matches(RotateRefreshTokenApiRequest request, RefreshToken refreshToken)
		{
			return r.Id == refreshToken.Id.Id.Id &&
				   r.Value == refreshToken.Id.Value &&
				   r.ExpiresAtUtc == refreshToken.ExpiresAtUtc;
		}
	}

	extension(IssueRefreshTokenCommandRequest command)
	{
		public bool Matches(IssueRefreshTokenApiRequest request)
		{
			return command.Name == request.Name &&
				   command.Password == request.Body.Password;
		}
	}

	extension(RotateRefreshTokenCommandRequest command)
	{
		public bool Matches(RotateRefreshTokenApiRequest request)
		{
			return command.Id == request.Id &&
				   command.Value == request.Value;
		}
	}

	extension(DeleteCurrentRefreshTokenCommandRequest command)
	{
		public bool Matches(DeleteCurrentRefreshTokenApiRequest request)
		{
			return command.Id == request.Id &&
				   command.Value == request.Value;
		}
	}

	extension(IssueRefreshTokenApiResponse response)
	{
		public bool Matches(IssueRefreshTokenApiRequest request)
		{
			return response.Response.Matches();
		}
	}


	extension(RotateRefreshTokenApiResponse response)
	{
		public bool Matches(RotateRefreshTokenApiRequest request)
		{
			return response.Response.Matches();
		}
	}

	extension(RefreshToken refreshToken)
	{
		public bool Matches(IssueRefreshTokenApiRequest request)
		{
			return refreshToken.Id.Id.Id.IsNotNullOrEmptyOrWhiteSpace() &&
				   refreshToken.Id.Value.IsNotNullOrEmptyOrWhiteSpace() &&
				   refreshToken.CreatedAtUtc != default &&
				   refreshToken.ExpiresAtUtc != default;
		}

		public bool Matches(RotateRefreshTokenApiRequest request)
		{
			return refreshToken.Id.Id.Matches(request.Id) &&
				   refreshToken.Id.Value.IsNotNullOrEmptyOrWhiteSpace() &&
				   refreshToken.CreatedAtUtc != default &&
				   refreshToken.ExpiresAtUtc != default;
		}
	}

	extension(ICollection<RefreshToken> refreshTokens)
	{
		public bool Matches(IssueRefreshTokenApiRequest request)
		{
			return refreshTokens.AllAndNotEmpty(refreshToken => refreshToken.Matches(request));
		}

		public bool Matches(RotateRefreshTokenApiRequest request)
		{
			return refreshTokens.AllAndNotEmpty(refreshToken => refreshToken.Matches(request));
		}
	}

	extension(RefreshTokenCookieApiResponse response)
	{
		public bool Matches(RefreshTokenId id)
		{
			return id.Matches(response.IdCookie.GetStringValue(), response.ValueCookie.GetStringValue());
		}
	}

	extension(RefreshTokenCookieApiResponse response)
	{
		public bool Matches(IssueRefreshTokenApiRequest request, RefreshToken refreshToken)
		{
			return response.Matches(refreshToken.Id) &&
				   response.IdCookie.MatchesHttpOnly(refreshToken.ExpiresAtUtc) &&
				   response.ValueCookie.MatchesHttpOnly(refreshToken.ExpiresAtUtc);
		}

		public bool Matches(RotateRefreshTokenApiRequest request, RefreshToken refreshToken)
		{
			return response.Matches(refreshToken.Id) &&
				   response.IdCookie.MatchesHttpOnly(refreshToken.ExpiresAtUtc) &&
				   response.ValueCookie.MatchesHttpOnly(refreshToken.ExpiresAtUtc);
		}
	}
}
