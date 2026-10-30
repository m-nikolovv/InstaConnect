using InstaConnect.Common.Tests.Features.DataAttributes.FormFiles.WebpDifferentCase;

namespace InstaConnect.Identity.Tests.Features.Users.DataAttributes.ProfileImage;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserProfileImageWebpDifferentCaseDataAttribute : WebpDifferentCaseFormFileDataAttribute
{
}
