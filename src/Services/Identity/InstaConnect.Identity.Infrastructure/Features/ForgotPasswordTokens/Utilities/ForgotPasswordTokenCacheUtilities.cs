using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.ValueObjects;

namespace InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Utilities;

public static class ForgotPasswordTokenCacheUtilities
{
	public const string GetByIdKeyPrefix = "identity-forgot-password-tokens-get-by-id";
	public const string ExistsByIdKeyPrefix = "identity-forgot-password-tokens-exists-by-id";

	public static string GetByIdKey(ForgotPasswordTokenId id)
	{
		const string Format = "{0}:{1}:{2}";

		return Format.FormatCurrentCulture(
			GetByIdKeyPrefix,
			id.Id.Id,
			id.Value);
	}

	public static string ExistsByIdKey(ForgotPasswordTokenId id)
	{
		const string Format = "{0}:{1}:{2}";

		return Format.FormatCurrentCulture(
			ExistsByIdKeyPrefix,
			id.Id.Id,
			id.Value);
	}

	public static string GetTag(ForgotPasswordTokenId id)
	{
		const string Format = "identity:tags:forgot-password-tokens:{0}:{1}";

		return Format.FormatCurrentCulture(
			id.Id.Id,
			id.Value).ToLowerCurrentCulture();
	}

	public static IEnumerable<string> GetTagRange(IEnumerable<ForgotPasswordTokenId> ids)
	{
		return ids.Select(GetTag);
	}
}
