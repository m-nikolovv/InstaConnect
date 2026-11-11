namespace InstaConnect.Follows.Infrastructure.Features.Follows.Utilities;

public static class FollowCacheUtilities
{
	public const string GetByIdKeyPrefix = "follows-follows-get-by-id";
	public const string ExistsByIdKeyPrefix = "follows-follows-exists-by-id";
	public const string GetResponseByIdKeyPrefix = "follows-follows-get-by-id-response";

	public static string GetByIdKey(FollowId id)
	{
		const string Format = "{0}:{1}:{2}";

		return Format.FormatCurrentCulture(
			GetByIdKeyPrefix,
			id.FollowerId.Id,
			id.FollowingId.Id);
	}

	public static string ExistsByIdKey(FollowId id)
	{
		const string Format = "{0}:{1}:{2}";

		return Format.FormatCurrentCulture(
			ExistsByIdKeyPrefix,
			id.FollowerId.Id,
			id.FollowingId.Id);
	}

	public static string GetResponseByIdKey(FollowId id, CurrentUserQuery currentUser)
	{
		const string Format = "{0}:{1}:{2}:{3}";

		return Format.FormatCurrentCulture(
			GetResponseByIdKeyPrefix,
			id.FollowerId.Id,
			id.FollowingId.Id,
			currentUser.Id.Id);
	}

	public static string GetTag(FollowId id)
	{
		const string Format = "follows:tags:follows:{0}:{1}";

		return Format.FormatCurrentCulture(
			id.FollowerId.Id,
			id.FollowingId.Id).ToLowerCurrentCulture();
	}

	public static IEnumerable<string> GetTagRange(IEnumerable<FollowId> ids)
	{
		return ids.Select(GetTag);
	}
}
