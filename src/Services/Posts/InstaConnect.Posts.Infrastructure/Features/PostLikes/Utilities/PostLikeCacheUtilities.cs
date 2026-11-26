namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Utilities;

public static class PostLikeCacheUtilities
{
	public const string GetResponseByIdKeyPrefix = "posts-post-likes-get-by-id-response";

	public static string GetResponseByIdKey(PostLikeId id, UserId currentUserId)
	{
		const string Format = "{0}:{1}:{2}:{3}";

		return Format.FormatCurrentCulture(
			GetResponseByIdKeyPrefix,
			id.Id.Id,
			id.UserId.Id,
			currentUserId.Id);
	}

	public static string GetTag(PostLikeId id)
	{
		const string Format = "posts:tags:post-likes:{0}:{1}";

		return Format.FormatCurrentCulture(
			id.Id.Id,
			id.UserId.Id).ToLowerCurrentCulture();
	}

	public static IEnumerable<string> GetTagRange(IEnumerable<PostLikeId> ids)
	{
		return ids.Select(GetTag);
	}
}
