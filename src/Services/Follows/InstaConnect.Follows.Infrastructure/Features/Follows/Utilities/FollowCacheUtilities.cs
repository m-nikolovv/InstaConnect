namespace InstaConnect.Follows.Infrastructure.Features.Follows.Utilities;

public static class FollowCacheUtilities
{
	public const string GetResponseByIdKeyPrefix = "follows-follows-get-by-id-response";

	public static string GetResponseByIdKey(FollowId id, UserId currentUserId)
	{
		const string Format = "{0}:{1}:{2}:{3}";

		return Format.FormatCurrentCulture(
			GetResponseByIdKeyPrefix,
			id.FollowerId.Id,
			id.FollowingId.Id,
			currentUserId.Id);
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
