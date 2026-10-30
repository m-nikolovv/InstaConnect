using InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.JpegDifferentCase;

namespace InstaConnect.Posts.Tests.Features.PostComments.DataAttributes.Images;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentImagesJpegDifferentCaseDataAttribute : JpegDifferentCaseFormFileCollectionDataAttribute
{
}
