using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.ValueObjects;
using InstaConnect.Identity.Infrastructure.Features.Users.Utilities;

namespace InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Utilities;

public static class ForgotPasswordTokenCacheUtilities
{
	public const string GetByIdKeyPrefix = "identity-forgot-password-tokens-get-by-id";
	public const string ExistsByIdKeyPrefix = "identity-forgot-password-tokens-exists-by-id";

	public static string GetByIdKey(ForgotPasswordTokenId id)
	{
		const string Format = GetByIdKeyPrefix + ":{0}:{1}";

		return Format.FormatCurrentCulture(id.Id.Id, id.Value);
	}

	public static string ExistsByIdKey(ForgotPasswordTokenId id)
	{
		const string Format = ExistsByIdKeyPrefix + ":{0}:{1}";

		return Format.FormatCurrentCulture(id.Id.Id, id.Value);
	}

	public static string GetTag(ForgotPasswordTokenId id)
	{
		const string Format = "identity:tags:forgot-password-tokens:{0}:{1}";

		return Format.FormatCurrentCulture(id.Id.Id, id.Value).ToUpperInvariant();
	}

	public static IEnumerable<string> GetTagRange(IEnumerable<ForgotPasswordTokenId> ids)
	{
		return ids.Select(GetTag);
	}

	public static IEnumerable<string> GetTagRange(ForgotPasswordTokenId id)
	{
		return [GetTag(id), UserCacheUtilities.GetTag(id.Id)];
	}
}
