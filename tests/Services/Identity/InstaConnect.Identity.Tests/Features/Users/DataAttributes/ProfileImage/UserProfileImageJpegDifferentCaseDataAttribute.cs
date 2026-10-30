using InstaConnect.Common.Tests.Features.DataAttributes.FormFiles.JpegDifferentCase;

namespace InstaConnect.Identity.Tests.Features.Users.DataAttributes.ProfileImage;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserProfileImageJpegDifferentCaseDataAttribute : JpegDifferentCaseFormFileDataAttribute
{
}
