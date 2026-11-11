using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.ValueObjects;
using InstaConnect.Identity.Infrastructure.Features.Users.Utilities;

namespace InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Utilities;

public static class RefreshTokenCacheUtilities
{
	public const string GetByIdKeyPrefix = "identity-refresh-tokens-get-by-id";

	public static string GetByIdKey(RefreshTokenId id)
	{
		const string Format = GetByIdKeyPrefix + ":{0}:{1}";

		return Format.FormatCurrentCulture(id.Id.Id, id.Value);
	}

	public static string GetTag(RefreshTokenId id)
	{
		const string Format = "identity:tags:refresh-tokens:{0}:{1}";

		return Format.FormatCurrentCulture(id.Id.Id, id.Value).ToUpperInvariant();
	}

	public static IEnumerable<string> GetTagRange(IEnumerable<RefreshTokenId> ids)
	{
		return ids.Select(GetTag);
	}

	public static IEnumerable<string> GetTagRange(RefreshTokenId id)
	{
		return [GetTag(id), UserCacheUtilities.GetTag(id.Id)];
	}
}
