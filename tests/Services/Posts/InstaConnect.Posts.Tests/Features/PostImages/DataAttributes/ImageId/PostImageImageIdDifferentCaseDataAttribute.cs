namespace InstaConnect.Posts.Tests.Features.PostImages.DataAttributes.ImageId;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostImageImageIdDifferentCaseDataAttribute : DifferentCaseStringDataAttribute
{
}
