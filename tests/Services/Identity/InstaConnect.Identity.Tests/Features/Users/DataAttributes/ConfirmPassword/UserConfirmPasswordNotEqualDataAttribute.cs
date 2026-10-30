using InstaConnect.Common.Tests.Features.DataAttributes.Strings.NotEqual;

namespace InstaConnect.Identity.Tests.Features.Users.DataAttributes.ConfirmPassword;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserConfirmPasswordNotEqualDataAttribute : NotEqualStringDataAttribute
{
	public UserConfirmPasswordNotEqualDataAttribute()
		: base(UserConfigurations.PasswordMaxLength, UserConfigurations.PasswordMinLength)
	{
	}
}
