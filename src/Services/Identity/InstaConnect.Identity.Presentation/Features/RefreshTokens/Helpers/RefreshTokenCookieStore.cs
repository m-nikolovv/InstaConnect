using InstaConnect.Common.Presentation.Features.Controllers.Abstractions;
using InstaConnect.Identity.Presentation.Features.RefreshTokens.Abstractions;
using InstaConnect.Identity.Presentation.Features.RefreshTokens.Utilities;

namespace InstaConnect.Identity.Presentation.Features.RefreshTokens.Helpers;

internal class RefreshTokenCookieStore : IRefreshTokenCookieStore
{
	private readonly ICookieStore _cookieStore;

	public RefreshTokenCookieStore(ICookieStore cookieStore)
	{
		_cookieStore = cookieStore;
	}

	public void Set(SetRefreshTokenCookieApiRequest request)
	{
		_cookieStore.SetHttpOnly(RefreshTokenCookieKeys.Id, request.Id, request.ExpiresAtUtc);
		_cookieStore.SetHttpOnly(RefreshTokenCookieKeys.Value, request.Value, request.ExpiresAtUtc);
	}

	public void Delete()
	{
		_cookieStore.Delete(RefreshTokenCookieKeys.Id);
		_cookieStore.Delete(RefreshTokenCookieKeys.Value);
	}
}
