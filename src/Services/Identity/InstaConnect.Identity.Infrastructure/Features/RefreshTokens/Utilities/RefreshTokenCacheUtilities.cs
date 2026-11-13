using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.ValueObjects;

namespace InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Utilities;

public static class RefreshTokenCacheUtilities
{
	public const string GetByIdKeyPrefix = "identity-refresh-tokens-get-by-id";

	public static string GetByIdKey(RefreshTokenId id)
	{
		const string Format = "{0}:{1}:{2}";

		return Format.FormatCurrentCulture(
			GetByIdKeyPrefix,
			id.Id.Id,
			id.Value);
	}

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
