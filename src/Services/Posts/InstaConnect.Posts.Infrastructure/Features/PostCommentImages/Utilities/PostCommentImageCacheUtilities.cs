using InstaConnect.Posts.Domain.Features.PostCommentImages.Models.ValueObjects;
using InstaConnect.Posts.Infrastructure.Features.PostComments.Utilities;
using InstaConnect.Posts.Infrastructure.Features.Posts.Utilities;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentImages.Utilities;

public static class PostCommentImageCacheUtilities
{
	public const string GetByIdKeyPrefix = "posts-post-comment-images-get-by-id";

	public static string GetByIdKey(PostCommentImageId id)
	{
		const string Format = GetByIdKeyPrefix + ":{0}:{1}:{2}";

		return Format.FormatCurrentCulture(id.Id.Id.Id, id.Id.CommentId, id.ImageId);
	}

	public static string GetTag(PostCommentImageId id)
	{
		const string Format = "posts:tags:post-comment-images:{0}:{1}:{2}";

		return Format.FormatCurrentCulture(id.Id.Id.Id, id.Id.CommentId, id.ImageId).ToUpperInvariant();
	}

	public static IEnumerable<string> GetTagRange(IEnumerable<PostCommentImageId> ids)
	{
		return ids.Select(GetTag);
	}

	public static IEnumerable<string> GetTagRange(PostCommentImageId id)
	{
		return [GetTag(id), PostCommentCacheUtilities.GetTag(id.Id), PostCacheUtilities.GetTag(id.Id.Id)];
	}
}
