namespace InstaConnect.Identity.Tests.Features.Users.DataAttributes.Password;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserPasswordTooShortDataAttribute : TooShortStringDataAttribute
{
	public UserPasswordTooShortDataAttribute()
		: base(UserConfigurations.PasswordMinLength)
	{
	}
}
