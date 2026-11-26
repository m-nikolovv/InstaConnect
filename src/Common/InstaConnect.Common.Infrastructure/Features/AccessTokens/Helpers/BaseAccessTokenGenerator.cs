using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

using InstaConnect.Common.Domain.Features.AccessTokens.Models;
using InstaConnect.Common.Domain.Features.DateTimes.Abstractions;
using InstaConnect.Common.Infrastructure.Features.AccessTokens.Abstractions;
using InstaConnect.Common.Infrastructure.Features.AccessTokens.Models;

using Microsoft.IdentityModel.Tokens;

namespace InstaConnect.Common.Infrastructure.Features.AccessTokens.Helpers;

internal class BaseAccessTokenGenerator : IBaseAccessTokenGenerator
{
	private readonly IEncoder _encoder;
	private readonly IDateTimeProvider _dateTimeProvider;
	private readonly AccessTokenOptions _accessTokenOptions;

	public BaseAccessTokenGenerator(
		IEncoder encoder,
		IDateTimeProvider dateTimeProvider,
		AccessTokenOptions accessTokenOptions)
	{
		_encoder = encoder;
		_dateTimeProvider = dateTimeProvider;
		_accessTokenOptions = accessTokenOptions;
	}

	public AccessToken Generate(IEnumerable<Claim> claims)
	{
		var claimsIdentity = new ClaimsIdentity(claims);

		var expiresAtUtc = _dateTimeProvider.GetUtcNow(_accessTokenOptions.LifetimeSeconds);
		var signingKey = new SymmetricSecurityKey(_encoder.GetBytesUTF8(_accessTokenOptions.SecurityKey));
		var tokenDescriptor = new SecurityTokenDescriptor
		{
			Subject = claimsIdentity,
			SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha512Signature),
			Issuer = _accessTokenOptions.Issuer,
			Audience = _accessTokenOptions.Audience,
			Expires = _dateTimeProvider.GetUtcNow(_accessTokenOptions.LifetimeSeconds)
		};

		var tokenHandler = new JwtSecurityTokenHandler();
		var securityToken = tokenHandler.CreateToken(tokenDescriptor);
		var value = tokenHandler.WriteToken(securityToken);

		return new(value, expiresAtUtc);
	}
}
