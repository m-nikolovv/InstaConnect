namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeCacheUtilities
{
	public const string GetResponseByIdKeyPrefix = "posts-post-comment-likes-get-by-id-response";

	public static string GetResponseByIdKey(PostCommentLikeId id, UserId currentUserId)
	{
		const string Format = "{0}:{1}:{2}:{3}:{4}";

		return Format.FormatCurrentCulture(
			GetResponseByIdKeyPrefix,
			id.CommentId.Id.Id,
			id.CommentId.CommentId,
			id.UserId.Id,
			currentUserId.Id);
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
