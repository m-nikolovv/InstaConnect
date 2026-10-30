namespace InstaConnect.Identity.Tests.Features.Users.DataAttributes.Password;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserPasswordTooLongWithMessageDataAttribute : TooLongStringWithMessageDataAttribute
{
	public UserPasswordTooLongWithMessageDataAttribute()
		: base(UserConfigurations.PasswordMaxLength)
	{
	}
}
