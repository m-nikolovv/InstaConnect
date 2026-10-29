using InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.InvalidContentType;
using InstaConnect.Posts.Domain.Features.PostCommentImages.Utilities;

namespace InstaConnect.Posts.Tests.Features.PostComments.DataAttributes.Images;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentImagesInvalidContentTypeWithMessageDataAttribute : InvalidContentTypeFormFileCollectionWithMessageDataAttribute
{
	public PostCommentImagesInvalidContentTypeWithMessageDataAttribute()
		: base(PostCommentImageConfigurations.ImageContentTypes)
	{
	}
}
