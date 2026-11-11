namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Utilities;

public static class PostCommentCacheUtilities
{
	public const string GetByIdKeyPrefix = "posts-post-comments-get-by-id";
	public const string ExistsByIdKeyPrefix = "posts-post-comments-exists-by-id";
	public const string GetResponseByIdKeyPrefix = "posts-post-comments-get-by-id-response";

	public static string GetByIdKey(PostCommentId id)
	{
		const string Format = "{0}:{1}:{2}";

		return Format.FormatCurrentCulture(
			GetByIdKeyPrefix,
			id.Id.Id,
			id.CommentId);
	}

	public static string ExistsByIdKey(PostCommentId id)
	{
		const string Format = "{0}:{1}:{2}";

		return Format.FormatCurrentCulture(
			ExistsByIdKeyPrefix,
			id.Id.Id,
			id.CommentId);
	}

	public static string GetResponseByIdKey(PostCommentId id, CurrentUserQuery currentUser)
	{
		const string Format = "{0}:{1}:{2}:{3}";

		return Format.FormatCurrentCulture(
			GetResponseByIdKeyPrefix,
			id.Id.Id,
			id.CommentId,
			currentUser.Id.Id);
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
}
