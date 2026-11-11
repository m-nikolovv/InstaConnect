namespace InstaConnect.Posts.Infrastructure.Features.Posts.Utilities;

public static class PostCacheUtilities
{
	public const string GetByIdKeyPrefix = "posts-posts-get-by-id";
	public const string ExistsByIdKeyPrefix = "posts-posts-exists-by-id";
	public const string GetResponseByIdKeyPrefix = "posts-posts-get-by-id-response";

	public static string GetByIdKey(PostId id)
	{
		const string Format = "{0}:{1}";

		return Format.FormatCurrentCulture(
			GetByIdKeyPrefix,
			id.Id);
	}

	public static string ExistsByIdKey(PostId id)
	{
		const string Format = "{0}:{1}";

		return Format.FormatCurrentCulture(
			ExistsByIdKeyPrefix,
			id.Id);
	}

	public static string GetResponseByIdKey(PostId id, CurrentUserQuery currentUser)
	{
		const string Format = "{0}:{1}:{2}";

		return Format.FormatCurrentCulture(
			GetResponseByIdKeyPrefix,
			id.Id,
			currentUser.Id.Id);
	}

	public static string GetTag(PostId id)
	{
		const string Format = "posts:tags:posts:{0}";

		return Format.FormatCurrentCulture(id.Id).ToLowerCurrentCulture();
	}

	public static IEnumerable<string> GetTagRange(IEnumerable<PostId> ids)
	{
		return ids.Select(GetTag);
	}
}
