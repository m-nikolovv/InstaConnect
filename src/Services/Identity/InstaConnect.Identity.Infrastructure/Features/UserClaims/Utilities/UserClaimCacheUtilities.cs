namespace InstaConnect.Identity.Infrastructure.Features.UserClaims.Utilities;

public static class UserClaimCacheUtilities
{
	public const string GetResponseByIdKeyPrefix = "identity-user-claims-get-by-id-response";

	public static string GetResponseByIdKey(UserClaimId id, UserId currentUserId)
	{
		const string Format = "{0}:{1}:{2}:{3}";

		return Format.FormatCurrentCulture(
			GetResponseByIdKeyPrefix,
			id.Id.Id,
			id.Claim,
			currentUserId.Id);
	}

	public static string GetTag(UserClaimId id)
	{
		const string Format = "identity:tags:user-claims:{0}:{1}";

		return Format.FormatCurrentCulture(
			id.Id.Id,
			id.Claim).ToLowerCurrentCulture();
	}

	public static IEnumerable<string> GetTagRange(IEnumerable<UserClaimId> ids)
	{
		return ids.Select(GetTag);
	}
}
