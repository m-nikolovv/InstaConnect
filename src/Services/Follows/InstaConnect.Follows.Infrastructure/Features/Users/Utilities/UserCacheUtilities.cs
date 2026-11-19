
namespace InstaConnect.Follows.Infrastructure.Features.Users.Utilities;

public static class UserCacheUtilities
{
	public const string GetResponseByIdKeyPrefix = "follows-users-get-by-id-response";

	public static string GetResponseByIdKey(UserId id, UserId currentUserId)
	{
		const string Format = "{0}:{1}:{2}";

		return Format.FormatCurrentCulture(
			GetResponseByIdKeyPrefix,
			id.Id,
			currentUserId.Id);
	}

	public static string GetTag(UserId id)
	{
		const string Format = "follows:tags:users:{0}";

		return Format.FormatCurrentCulture(id.Id).ToLowerCurrentCulture();
	}

	public static IEnumerable<string> GetTagRange(IEnumerable<UserId> ids)
	{
		return ids.Select(GetTag);
	}
}
