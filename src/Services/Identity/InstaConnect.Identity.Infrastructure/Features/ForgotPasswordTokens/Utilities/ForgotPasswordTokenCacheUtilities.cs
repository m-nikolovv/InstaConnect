using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.ValueObjects;

namespace InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Utilities;

public static class ForgotPasswordTokenCacheUtilities
{
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
