using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.ValueObjects;

namespace InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Utilities;

public static class RefreshTokenCacheUtilities
{
	public static string GetTag(RefreshTokenId id)
	{
		const string Format = "identity:tags:refresh-tokens:{0}:{1}";

		return Format.FormatCurrentCulture(
			id.Id.Id,
			id.Value).ToLowerCurrentCulture();
	}

	public static IEnumerable<string> GetTagRange(IEnumerable<RefreshTokenId> ids)
	{
		return ids.Select(GetTag);
	}
}
