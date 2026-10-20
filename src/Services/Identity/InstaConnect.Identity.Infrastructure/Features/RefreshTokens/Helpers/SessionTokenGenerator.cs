using InstaConnect.Identity.Domain.Features.RefreshTokens.Abstractions;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Responses;

namespace InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Helpers;

internal class SessionTokenGenerator : ISessionTokenGenerator
{
	private readonly IAccessTokenGenerator _accessTokenGenerator;

	public SessionTokenGenerator(IAccessTokenGenerator accessTokenGenerator)
	{
		_accessTokenGenerator = accessTokenGenerator;
	}

	public SessionToken Generate(RefreshToken refreshToken)
	{
		var accessToken = _accessTokenGenerator.Generate(refreshToken.User!);

		return new(refreshToken.Id, accessToken, refreshToken.ExpiresAtUtc);
	}
}
