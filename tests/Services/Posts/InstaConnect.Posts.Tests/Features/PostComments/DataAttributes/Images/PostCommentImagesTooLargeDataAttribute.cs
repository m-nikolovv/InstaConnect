using InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.TooLarge;
using InstaConnect.Posts.Domain.Features.PostCommentImages.Utilities;

namespace InstaConnect.Posts.Tests.Features.PostComments.DataAttributes.Images;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentImagesTooLargeDataAttribute : TooLargeFormFileCollectionDataAttribute
{
	public PostCommentImagesTooLargeDataAttribute()
		: base(PostCommentImageConfigurations.ImageMaxSize)
	{
	}
}
