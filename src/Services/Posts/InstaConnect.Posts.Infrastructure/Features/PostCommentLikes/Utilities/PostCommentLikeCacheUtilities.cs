namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeCacheUtilities
{
	public const string GetByIdKeyPrefix = "posts-post-comment-likes-get-by-id";
	public const string ExistsByIdKeyPrefix = "posts-post-comment-likes-exists-by-id";
	public const string GetResponseByIdKeyPrefix = "posts-post-comment-likes-get-by-id-response";

	public static string GetByIdKey(PostCommentLikeId id)
	{
		const string Format = "{0}:{1}:{2}:{3}";

		return Format.FormatCurrentCulture(
			GetByIdKeyPrefix,
			id.CommentId.Id.Id,
			id.CommentId.CommentId,
			id.UserId.Id);
	}

	public static string ExistsByIdKey(PostCommentLikeId id)
	{
		const string Format = "{0}:{1}:{2}:{3}";

		return Format.FormatCurrentCulture(
			ExistsByIdKeyPrefix,
			id.CommentId.Id.Id,
			id.CommentId.CommentId,
			id.UserId.Id);
	}

	public static string GetResponseByIdKey(PostCommentLikeId id, CurrentUserQuery currentUser)
	{
		const string Format = "{0}:{1}:{2}:{3}:{4}";

		return Format.FormatCurrentCulture(
			GetResponseByIdKeyPrefix,
			id.CommentId.Id.Id,
			id.CommentId.CommentId,
			id.UserId.Id,
			currentUser.Id.Id);
	}

	public static string GetTag(PostCommentLikeId id)
	{
		const string Format = "posts:tags:post-comment-likes:{0}:{1}:{2}";

		return Format.FormatCurrentCulture(
			id.CommentId.Id.Id,
			id.CommentId.CommentId,
			id.UserId.Id).ToLowerCurrentCulture();
	}

	public static IEnumerable<string> GetTagRange(IEnumerable<PostCommentLikeId> ids)
	{
		return ids.Select(GetTag);
	}
}
