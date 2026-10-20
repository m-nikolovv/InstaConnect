using InstaConnect.Identity.Application.Features.RefreshTokens.Models;
using InstaConnect.Identity.Application.Tests.Features.RefreshTokens.Utilities;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Requests;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.ValueObjects;

namespace InstaConnect.Identity.Application.Tests.Features.RefreshTokens.Utilities;

public static class RefreshTokenEquals
{
	extension(IssueRefreshTokenCommand command)
	{
		public bool Matches(IssueRefreshTokenCommandRequest request)
		{
			return command.Name.Matches(request.Name) &&
				   command.Password == request.Password;
		}
	}

	extension(RotateRefreshTokenCommand command)
	{
		public bool Matches(RotateRefreshTokenCommandRequest request)
		{
			return command.Id.Matches(request.Id, request.Value);
		}
	}

	extension(DeleteRefreshTokenCommand command)
	{
		public bool Matches(DeleteCurrentRefreshTokenCommandRequest request)
		{
			return command.Id.Matches(request.Id, request.Value);
		}
	}

	extension(IssueRefreshTokenCommandResponse response)
	{
		public bool Matches(IssueRefreshTokenCommandRequest request, RefreshToken refreshToken)
		{
			return response.Response.Matches(refreshToken);
		}
	}

	extension(RotateRefreshTokenCommandResponse response)
	{
		public bool Matches(RotateRefreshTokenCommandRequest request, RefreshToken refreshToken)
		{
			return response.Response.Matches(refreshToken);
		}
	}

	extension(RefreshToken refreshToken)
	{
		public bool Matches(IssueRefreshTokenCommandRequest request)
		{
			return refreshToken.Id.Id.Id.IsNotNullOrEmptyOrWhiteSpace() &&
				   refreshToken.Id.Value.IsNotNullOrEmptyOrWhiteSpace() &&
				   refreshToken.CreatedAtUtc != default &&
				   refreshToken.ExpiresAtUtc != default;
		}

		public bool Matches(RotateRefreshTokenCommandRequest request)
		{
			return refreshToken.Id.Id.Matches(request.Id) &&
				   refreshToken.Id.Value.IsNotNullOrEmptyOrWhiteSpace() &&
				   refreshToken.CreatedAtUtc != default &&
				   refreshToken.ExpiresAtUtc != default;
		}
	}

	extension(RefreshTokenIdCommandResponse response)
	{
		public bool Matches(RefreshTokenId id)
		{
			return id.Matches(response.Id, response.Value);
		}
	}

	extension(SessionTokenCommandResponse response)
	{
		public bool Matches(RefreshToken refreshToken)
		{
			return response.Id.Matches(refreshToken.Id) &&
				   response.AccessToken.Matches() &&
				   response.ExpiresAtUtc == refreshToken.ExpiresAtUtc;
		}
	}
}
