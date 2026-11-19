namespace InstaConnect.Posts.Infrastructure.Features.Posts.Utilities;

public static class PostCacheUtilities
{
	public const string GetResponseByIdKeyPrefix = "posts-posts-get-by-id-response";

	public static string GetResponseByIdKey(PostId id, UserId currentUserId)
	{
		const string Format = "{0}:{1}:{2}";

		return Format.FormatCurrentCulture(
			GetResponseByIdKeyPrefix,
			id.Id,
			currentUserId.Id);
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

	public static string GetResponseTag(PostId id)
	{
		const string Format = "posts:tags:posts:responses:{0}";

		return Format.FormatCurrentCulture(id.Id).ToLowerCurrentCulture();
	}

	public static IEnumerable<string> GetResponseTagRange(IEnumerable<PostId> ids)
	{
		return ids.Select(GetResponseTag);
	}
}
