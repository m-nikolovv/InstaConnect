using InstaConnect.Posts.Domain.Features.PostImages.Models.ValueObjects;

namespace InstaConnect.Posts.Infrastructure.Features.PostImages.Utilities;

public static class PostImageCacheUtilities
{
	public static string GetTag(PostImageId id)
	{
		const string Format = "posts:tags:post-images:{0}:{1}";

		return Format.FormatCurrentCulture(
			id.Id.Id,
			id.ImageId).ToLowerCurrentCulture();
	}

	public static IEnumerable<string> GetTagRange(IEnumerable<PostImageId> ids)
	{
		return ids.Select(GetTag);
	}
}
