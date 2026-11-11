using InstaConnect.Posts.Infrastructure.Features.Posts.Utilities;
using InstaConnect.Posts.Infrastructure.Features.Users.Utilities;

namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Utilities;

public static class PostCommentCacheUtilities
{
	public const string GetByIdKeyPrefix = "posts-post-comments-get-by-id";
	public const string ExistsByIdKeyPrefix = "posts-post-comments-exists-by-id";
	public const string GetResponseByIdKeyPrefix = "posts-post-comments-get-by-id-response";

	public static string GetByIdKey(PostCommentId id)
	{
		const string Format = GetByIdKeyPrefix + ":{0}:{1}";

		return Format.FormatCurrentCulture(id.Id.Id, id.CommentId);
	}

	public static string ExistsByIdKey(PostCommentId id)
	{
		const string Format = ExistsByIdKeyPrefix + ":{0}:{1}";

		return Format.FormatCurrentCulture(id.Id.Id, id.CommentId);
	}

	public static string GetResponseByIdKey(PostCommentId id, CurrentUserQuery currentUser)
	{
		const string Format = GetResponseByIdKeyPrefix + ":{0}:{1}:{2}";

		return Format.FormatCurrentCulture(id.Id.Id, id.CommentId, currentUser.Id.Id);
	}

	public static string GetTag(PostCommentId id)
	{
		const string Format = "posts:tags:post-comments:{0}:{1}";

		return Format.FormatCurrentCulture(id.Id.Id, id.CommentId).ToUpperInvariant();
	}

	public static IEnumerable<string> GetTagRange(IEnumerable<PostCommentId> ids)
	{
		return ids.Select(GetTag);
	}

	public static IEnumerable<string> GetTagRange(PostCommentId id)
	{
		return [GetTag(id), PostCacheUtilities.GetTag(id.Id)];
	}

	public static IEnumerable<string> GetTagRange(PostComment entity)
	{
		return [.. GetTagRange(entity.Id), UserCacheUtilities.GetTag(entity.UserId)];
	}

	public static IEnumerable<string> GetTagRange(PostCommentResponse response)
	{
		List<string> tags = [GetTag(response.Id), PostCacheUtilities.GetTag(response.Id.Id), UserCacheUtilities.GetTag(response.UserId)];

		if (response.Post != null)
		{
			tags.Add(UserCacheUtilities.GetTag(response.Post.UserId));
		}

		return tags;
	}
}
