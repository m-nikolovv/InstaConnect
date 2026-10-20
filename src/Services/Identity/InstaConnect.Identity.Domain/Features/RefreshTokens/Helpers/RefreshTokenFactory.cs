using InstaConnect.Common.Domain.Features.Guids.Abstractions;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Options;

using Microsoft.Extensions.Options;

namespace InstaConnect.Identity.Domain.Features.RefreshTokens.Helpers;

internal class RefreshTokenFactory : IRefreshTokenFactory
{
	private readonly IGuidProvider _guidProvider;
	private readonly IDateTimeProvider _dateTimeProvider;
	private readonly RefreshTokenOptions _refreshTokenOptions;

	public RefreshTokenFactory(
		IGuidProvider guidProvider,
		IDateTimeProvider dateTimeProvider,
		IOptions<RefreshTokenOptions> refreshTokenOptions)
	{
		_guidProvider = guidProvider;
		_dateTimeProvider = dateTimeProvider;
		_refreshTokenOptions = refreshTokenOptions.Value;
	}

	public RefreshToken Create(UserId id)
	{
		var value = _guidProvider.NewStringGuid();
		var expiresAt = _dateTimeProvider.GetOffsetUtcNow(_refreshTokenOptions.LifetimeSeconds);
		var utcNow = _dateTimeProvider.GetOffsetUtcNow();
		var refreshToken = new RefreshToken(
			new(id, value),
			expiresAt,
			utcNow);

		return refreshToken;
	}
}
