using InstaConnect.Common.Tests.Features.DataAttributes.FormFiles.InvalidContentType;

namespace InstaConnect.Identity.Tests.Features.Users.DataAttributes.ProfileImage;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserProfileImageInvalidContentTypeWithMessageDataAttribute : InvalidContentTypeFormFileWithMessageDataAttribute
{
	public UserProfileImageInvalidContentTypeWithMessageDataAttribute()
		: base(UserConfigurations.ProfileImageContentTypes)
	{
	}
}
