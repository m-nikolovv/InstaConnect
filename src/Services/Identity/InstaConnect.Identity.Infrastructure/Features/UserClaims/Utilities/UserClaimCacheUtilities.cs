using InstaConnect.Identity.Infrastructure.Features.Users.Utilities;

namespace InstaConnect.Identity.Infrastructure.Features.UserClaims.Utilities;

public static class UserClaimCacheUtilities
{
	public const string GetByIdKeyPrefix = "identity-user-claims-get-by-id";
	public const string ExistsByIdKeyPrefix = "identity-user-claims-exists-by-id";
	public const string GetResponseByIdKeyPrefix = "identity-user-claims-get-by-id-response";

	public static string GetByIdKey(UserClaimId id)
	{
		const string Format = GetByIdKeyPrefix + ":{0}:{1}";

		return Format.FormatCurrentCulture(id.Id.Id, id.Claim);
	}

	public static string ExistsByIdKey(UserClaimId id)
	{
		const string Format = ExistsByIdKeyPrefix + ":{0}:{1}";

		return Format.FormatCurrentCulture(id.Id.Id, id.Claim);
	}

	public static string GetResponseByIdKey(UserClaimId id, CurrentUserQuery currentUser)
	{
		const string Format = GetResponseByIdKeyPrefix + ":{0}:{1}:{2}";

		return Format.FormatCurrentCulture(id.Id.Id, id.Claim, currentUser.Id.Id);
	}

	public static string GetTag(UserClaimId id)
	{
		const string Format = "identity:tags:user-claims:{0}:{1}";

		return Format.FormatCurrentCulture(id.Id.Id, id.Claim).ToUpperInvariant();
	}

	public static IEnumerable<string> GetTagRange(IEnumerable<UserClaimId> ids)
	{
		return ids.Select(GetTag);
	}

	public static IEnumerable<string> GetTagRange(UserClaimId id)
	{
		return [GetTag(id), UserCacheUtilities.GetTag(id.Id)];
	}
}
