using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.ValueObjects;

namespace InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Utilities;

public static class EmailConfirmationTokenCacheUtilities
{
	public const string GetByIdKeyPrefix = "identity-email-confirmation-tokens-get-by-id";
	public const string ExistsByIdKeyPrefix = "identity-email-confirmation-tokens-exists-by-id";

	public static string GetByIdKey(EmailConfirmationTokenId id)
	{
		const string Format = "{0}:{1}:{2}";

		return Format.FormatCurrentCulture(
			GetByIdKeyPrefix,
			id.Id.Id,
			id.Value);
	}

	public static string ExistsByIdKey(EmailConfirmationTokenId id)
	{
		const string Format = "{0}:{1}:{2}";

		return Format.FormatCurrentCulture(
			ExistsByIdKeyPrefix,
			id.Id.Id,
			id.Value);
	}

	public static string GetTag(EmailConfirmationTokenId id)
	{
		const string Format = "identity:tags:email-confirmation-tokens:{0}:{1}";

		return Format.FormatCurrentCulture(
			id.Id.Id,
			id.Value).ToLowerCurrentCulture();
	}

	public static IEnumerable<string> GetTagRange(IEnumerable<EmailConfirmationTokenId> ids)
	{
		return ids.Select(GetTag);
	}
}
