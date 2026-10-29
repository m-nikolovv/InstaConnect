using InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.InvalidContentType;
using InstaConnect.Posts.Domain.Features.PostImages.Utilities;

namespace InstaConnect.Posts.Tests.Features.Posts.DataAttributes.Images;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostImagesInvalidContentTypeWithMessageDataAttribute : InvalidContentTypeFormFileCollectionWithMessageDataAttribute
{
	public PostImagesInvalidContentTypeWithMessageDataAttribute()
		: base(PostImageConfigurations.ImageContentTypes)
	{
	}
}
