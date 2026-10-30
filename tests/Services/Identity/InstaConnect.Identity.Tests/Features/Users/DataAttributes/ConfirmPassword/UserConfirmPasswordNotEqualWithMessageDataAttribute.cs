using InstaConnect.Common.Tests.Features.DataAttributes.Strings.NotEqual;

namespace InstaConnect.Identity.Tests.Features.Users.DataAttributes.ConfirmPassword;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserConfirmPasswordNotEqualWithMessageDataAttribute : NotEqualStringWithMessageDataAttribute
{
	public UserConfirmPasswordNotEqualWithMessageDataAttribute(string equalPropertyName)
		: base(equalPropertyName, UserConfigurations.PasswordMaxLength, UserConfigurations.PasswordMinLength)
	{
	}
}
