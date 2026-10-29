using InstaConnect.Common.Tests.Features.DataAttributes.FormFiles.TooLarge;

namespace InstaConnect.Identity.Tests.Features.Users.DataAttributes.ProfileImage;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserProfileImageTooLargeDataAttribute : TooLargeFormFileDataAttribute
{
	public UserProfileImageTooLargeDataAttribute()
		: base(UserConfigurations.ProfileImageMaxSize)
	{
	}
}
