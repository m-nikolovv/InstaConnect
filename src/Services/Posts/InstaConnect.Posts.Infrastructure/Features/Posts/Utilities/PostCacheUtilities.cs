using InstaConnect.Posts.Infrastructure.Features.Users.Utilities;

namespace InstaConnect.Posts.Infrastructure.Features.Posts.Utilities;

public static class PostCacheUtilities
{
	public const string GetByIdKeyPrefix = "posts-posts-get-by-id";
	public const string ExistsByIdKeyPrefix = "posts-posts-exists-by-id";
	public const string GetResponseByIdKeyPrefix = "posts-posts-get-by-id-response";

	public static string GetByIdKey(PostId id)
	{
		const string Format = GetByIdKeyPrefix + ":{0}";

		return Format.FormatCurrentCulture(id.Id);
	}

	public static string ExistsByIdKey(PostId id)
	{
		const string Format = ExistsByIdKeyPrefix + ":{0}";

		return Format.FormatCurrentCulture(id.Id);
	}

	public static string GetResponseByIdKey(PostId id, CurrentUserQuery currentUser)
	{
		const string Format = GetResponseByIdKeyPrefix + ":{0}:{1}";

		return Format.FormatCurrentCulture(id.Id, currentUser.Id.Id);
	}

	public static string GetTag(PostId id)
	{
		const string Format = "posts:tags:posts:{0}";

		return Format.FormatCurrentCulture(id.Id).ToUpperInvariant();
	}

	public static IEnumerable<string> GetTagRange(IEnumerable<PostId> ids)
	{
		return ids.Select(GetTag);
	}

	public static IEnumerable<string> GetTagRange(PostId id)
	{
		return [GetTag(id)];
	}

	public static IEnumerable<string> GetTagRange(Post entity)
	{
		return [.. GetTagRange(entity.Id), UserCacheUtilities.GetTag(entity.UserId)];
	}

	public static IEnumerable<string> GetTagRange(PostResponse response)
	{
		return [GetTag(response.Id), UserCacheUtilities.GetTag(response.UserId)];
	}
}
