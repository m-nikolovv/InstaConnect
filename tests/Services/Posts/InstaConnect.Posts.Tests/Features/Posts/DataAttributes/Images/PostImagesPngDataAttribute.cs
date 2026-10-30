using InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.Png;

namespace InstaConnect.Posts.Tests.Features.Posts.DataAttributes.Images;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostImagesPngDataAttribute : PngFormFileCollectionDataAttribute
{
}
