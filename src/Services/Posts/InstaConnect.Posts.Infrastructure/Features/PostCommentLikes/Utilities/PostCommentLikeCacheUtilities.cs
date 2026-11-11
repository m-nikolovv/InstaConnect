using InstaConnect.Posts.Infrastructure.Features.PostComments.Utilities;
using InstaConnect.Posts.Infrastructure.Features.Posts.Utilities;
using InstaConnect.Posts.Infrastructure.Features.Users.Utilities;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeCacheUtilities
{
	public const string GetByIdKeyPrefix = "posts-post-comment-likes-get-by-id";
	public const string ExistsByIdKeyPrefix = "posts-post-comment-likes-exists-by-id";
	public const string GetResponseByIdKeyPrefix = "posts-post-comment-likes-get-by-id-response";

	public static string GetByIdKey(PostCommentLikeId id)
	{
		const string Format = GetByIdKeyPrefix + ":{0}:{1}:{2}";

		return Format.FormatCurrentCulture(id.CommentId.Id.Id, id.CommentId.CommentId, id.UserId.Id);
	}

	public static string ExistsByIdKey(PostCommentLikeId id)
	{
		const string Format = ExistsByIdKeyPrefix + ":{0}:{1}:{2}";

		return Format.FormatCurrentCulture(id.CommentId.Id.Id, id.CommentId.CommentId, id.UserId.Id);
	}

	public static string GetResponseByIdKey(PostCommentLikeId id, CurrentUserQuery currentUser)
	{
		const string Format = GetResponseByIdKeyPrefix + ":{0}:{1}:{2}:{3}";

		return Format.FormatCurrentCulture(id.CommentId.Id.Id, id.CommentId.CommentId, id.UserId.Id, currentUser.Id.Id);
	}

	public static string GetTag(PostCommentLikeId id)
	{
		const string Format = "posts:tags:post-comment-likes:{0}:{1}:{2}";

		return Format.FormatCurrentCulture(id.CommentId.Id.Id, id.CommentId.CommentId, id.UserId.Id).ToUpperInvariant();
	}

	public static IEnumerable<string> GetTagRange(IEnumerable<PostCommentLikeId> ids)
	{
		return ids.Select(GetTag);
	}

	public static IEnumerable<string> GetTagRange(PostCommentLikeId id)
	{
		return [GetTag(id), PostCommentCacheUtilities.GetTag(id.CommentId), PostCacheUtilities.GetTag(id.CommentId.Id), UserCacheUtilities.GetTag(id.UserId)];
	}

	public static IEnumerable<string> GetTagRange(PostCommentLikeResponse response)
	{
		List<string> tags = [GetTag(response.Id), PostCommentCacheUtilities.GetTag(response.Id.CommentId), PostCacheUtilities.GetTag(response.Id.CommentId.Id), UserCacheUtilities.GetTag(response.Id.UserId)];

		if (response.PostComment != null)
		{
			tags.Add(UserCacheUtilities.GetTag(response.PostComment.UserId));
		}

		if (response.PostComment?.Post != null)
		{
			tags.Add(UserCacheUtilities.GetTag(response.PostComment.Post.UserId));
		}

		return tags;
	}
}
