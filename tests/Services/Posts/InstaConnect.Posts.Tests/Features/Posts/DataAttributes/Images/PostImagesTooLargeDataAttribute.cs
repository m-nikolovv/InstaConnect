using InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.TooLarge;
using InstaConnect.Posts.Domain.Features.PostImages.Utilities;

namespace InstaConnect.Posts.Tests.Features.Posts.DataAttributes.Images;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostImagesTooLargeDataAttribute : TooLargeFormFileCollectionDataAttribute
{
	public PostImagesTooLargeDataAttribute()
		: base(PostImageConfigurations.ImageMaxSize)
	{
	}
}
