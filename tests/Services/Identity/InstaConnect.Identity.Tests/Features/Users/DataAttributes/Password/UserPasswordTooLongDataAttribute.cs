namespace InstaConnect.Identity.Tests.Features.Users.DataAttributes.Password;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserPasswordTooLongDataAttribute : TooLongStringDataAttribute
{
	public UserPasswordTooLongDataAttribute()
		: base(UserConfigurations.PasswordMaxLength)
	{
	}
}
