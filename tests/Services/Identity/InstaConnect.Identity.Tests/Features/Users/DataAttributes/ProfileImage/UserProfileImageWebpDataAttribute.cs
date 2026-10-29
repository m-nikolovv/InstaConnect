using InstaConnect.Common.Tests.Features.DataAttributes.FormFiles.Webp;

namespace InstaConnect.Identity.Tests.Features.Users.DataAttributes.ProfileImage;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserProfileImageWebpDataAttribute : WebpFormFileDataAttribute
{
}
