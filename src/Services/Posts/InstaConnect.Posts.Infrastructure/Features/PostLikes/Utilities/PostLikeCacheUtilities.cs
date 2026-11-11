using InstaConnect.Posts.Infrastructure.Features.Posts.Utilities;
using InstaConnect.Posts.Infrastructure.Features.Users.Utilities;

namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Utilities;

public static class PostLikeCacheUtilities
{
	public const string GetByIdKeyPrefix = "posts-post-likes-get-by-id";
	public const string ExistsByIdKeyPrefix = "posts-post-likes-exists-by-id";
	public const string GetResponseByIdKeyPrefix = "posts-post-likes-get-by-id-response";

	public static string GetByIdKey(PostLikeId id)
	{
		const string Format = GetByIdKeyPrefix + ":{0}:{1}";

		return Format.FormatCurrentCulture(id.Id.Id, id.UserId.Id);
	}

	public static string ExistsByIdKey(PostLikeId id)
	{
		const string Format = ExistsByIdKeyPrefix + ":{0}:{1}";

		return Format.FormatCurrentCulture(id.Id.Id, id.UserId.Id);
	}

	public static string GetResponseByIdKey(PostLikeId id, CurrentUserQuery currentUser)
	{
		const string Format = GetResponseByIdKeyPrefix + ":{0}:{1}:{2}";

		return Format.FormatCurrentCulture(id.Id.Id, id.UserId.Id, currentUser.Id.Id);
	}

	public static string GetTag(PostLikeId id)
	{
		const string Format = "posts:tags:post-likes:{0}:{1}";

		return Format.FormatCurrentCulture(id.Id.Id, id.UserId.Id).ToUpperInvariant();
	}

	public static IEnumerable<string> GetTagRange(IEnumerable<PostLikeId> ids)
	{
		return ids.Select(GetTag);
	}

	public static IEnumerable<string> GetTagRange(PostLikeId id)
	{
		return [GetTag(id), PostCacheUtilities.GetTag(id.Id), UserCacheUtilities.GetTag(id.UserId)];
	}

	public static IEnumerable<string> GetTagRange(PostLikeResponse response)
	{
		List<string> tags = [GetTag(response.Id), PostCacheUtilities.GetTag(response.Id.Id), UserCacheUtilities.GetTag(response.Id.UserId)];

		if (response.Post != null)
		{
			tags.Add(UserCacheUtilities.GetTag(response.Post.UserId));
		}

		return tags;
	}
}
