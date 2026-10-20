using InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.Empty;

namespace InstaConnect.Posts.Tests.Features.PostComments.DataAttributes.Images;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentImagesEmptyDataAttribute : EmptyFormFileCollectionDataAttribute
{
}
