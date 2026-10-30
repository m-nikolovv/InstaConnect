namespace InstaConnect.Identity.Tests.Features.Users.DataAttributes.Password;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserPasswordTooShortWithMessageDataAttribute : TooShortStringWithMessageDataAttribute
{
	public UserPasswordTooShortWithMessageDataAttribute()
		: base(UserConfigurations.PasswordMinLength)
	{
	}
}
