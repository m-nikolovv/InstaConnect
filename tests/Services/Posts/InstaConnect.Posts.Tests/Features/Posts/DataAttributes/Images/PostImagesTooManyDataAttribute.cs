using InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.TooMany;

namespace InstaConnect.Posts.Tests.Features.Posts.DataAttributes.Images;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostImagesTooManyDataAttribute : TooManyFormFileCollectionDataAttribute
{
	public PostImagesTooManyDataAttribute()
		: base(PostConfigurations.ImagesMaxCount)
	{
	}
}
