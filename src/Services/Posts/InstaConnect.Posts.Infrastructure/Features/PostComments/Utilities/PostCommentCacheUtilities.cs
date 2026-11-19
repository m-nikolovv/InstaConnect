namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Utilities;

public static class PostCommentCacheUtilities
{
	public const string GetResponseByIdKeyPrefix = "posts-post-comments-get-by-id-response";

	public static string GetResponseByIdKey(PostCommentId id, UserId currentUserId)
	{
		const string Format = "{0}:{1}:{2}:{3}";

		return Format.FormatCurrentCulture(
			GetResponseByIdKeyPrefix,
			id.Id.Id,
			id.CommentId,
			currentUserId.Id);
	}

	public static string GetTag(PostCommentId id)
	{
		const string Format = "posts:tags:post-comments:{0}:{1}";

		return Format.FormatCurrentCulture(
			id.Id.Id,
			id.CommentId).ToLowerCurrentCulture();
	}

	public static IEnumerable<string> GetTagRange(IEnumerable<PostCommentId> ids)
	{
		return ids.Select(GetTag);
	}

	public static string GetResponseTag(PostCommentId id)
	{
		const string Format = "posts:tags:post-comments:responses:{0}:{1}";

		return Format.FormatCurrentCulture(
			id.Id.Id,
			id.CommentId).ToLowerCurrentCulture();
	}

	public static IEnumerable<string> GetResponseTagRange(IEnumerable<PostCommentId> ids)
	{
		return ids.Select(GetResponseTag);
	}
}
