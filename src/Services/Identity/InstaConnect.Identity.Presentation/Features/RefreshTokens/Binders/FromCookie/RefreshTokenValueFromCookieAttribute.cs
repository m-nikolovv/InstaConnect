using InstaConnect.Common.Presentation.Features.Controllers.Helpers.FromCookie;
using InstaConnect.Identity.Presentation.Features.RefreshTokens.Utilities;

namespace InstaConnect.Identity.Presentation.Features.RefreshTokens.Binders.FromCookie;

[AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property, AllowMultiple = false)]
public sealed class RefreshTokenValueFromCookieAttribute : FromCookieAttribute
{
	public RefreshTokenValueFromCookieAttribute() : base(RefreshTokenCookieKeys.Value)
	{
	}
}
