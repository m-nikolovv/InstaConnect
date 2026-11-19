using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.ValueObjects;

namespace InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Utilities;

public static class EmailConfirmationTokenCacheUtilities
{
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
