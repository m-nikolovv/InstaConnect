using InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.TooMany;

namespace InstaConnect.Posts.Tests.Features.Posts.DataAttributes.Images;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostImagesTooManyWithMessageDataAttribute : TooManyFormFileCollectionWithMessageDataAttribute
{
	public PostImagesTooManyWithMessageDataAttribute()
		: base(PostConfigurations.ImagesMaxCount)
	{
	}
}
