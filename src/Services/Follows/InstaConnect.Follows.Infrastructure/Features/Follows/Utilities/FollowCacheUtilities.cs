using InstaConnect.Follows.Infrastructure.Features.Users.Utilities;

namespace InstaConnect.Follows.Infrastructure.Features.Follows.Utilities;

public static class FollowCacheUtilities
{
	public const string GetByIdKeyPrefix = "follows-follows-get-by-id";
	public const string ExistsByIdKeyPrefix = "follows-follows-exists-by-id";
	public const string GetResponseByIdKeyPrefix = "follows-follows-get-by-id-response";

	public static string GetByIdKey(FollowId id)
	{
		const string Format = GetByIdKeyPrefix + ":{0}:{1}";

		return Format.FormatCurrentCulture(id.FollowerId.Id, id.FollowingId.Id);
	}

	public static string ExistsByIdKey(FollowId id)
	{
		const string Format = ExistsByIdKeyPrefix + ":{0}:{1}";

		return Format.FormatCurrentCulture(id.FollowerId.Id, id.FollowingId.Id);
	}

	public static string GetResponseByIdKey(FollowId id, CurrentUserQuery currentUser)
	{
		const string Format = GetResponseByIdKeyPrefix + ":{0}:{1}:{2}";

		return Format.FormatCurrentCulture(id.FollowerId.Id, id.FollowingId.Id, currentUser.Id.Id);
	}

	public static string GetTag(FollowId id)
	{
		const string Format = "follows:tags:follows:{0}:{1}";

		return Format.FormatCurrentCulture(id.FollowerId.Id, id.FollowingId.Id).ToUpperInvariant();
	}

	public static IEnumerable<string> GetTagRange(IEnumerable<FollowId> ids)
	{
		return ids.Select(GetTag);
	}

	public static IEnumerable<string> GetTagRange(FollowId id)
	{
		return [GetTag(id), UserCacheUtilities.GetTag(id.FollowerId), UserCacheUtilities.GetTag(id.FollowingId)];
	}
}
