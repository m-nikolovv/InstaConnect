using InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.TooMany;

namespace InstaConnect.Posts.Tests.Features.PostComments.DataAttributes.Images;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentImagesTooManyDataAttribute : TooManyFormFileCollectionDataAttribute
{
	public PostCommentImagesTooManyDataAttribute()
		: base(PostCommentConfigurations.ImagesMaxCount)
	{
	}
}
