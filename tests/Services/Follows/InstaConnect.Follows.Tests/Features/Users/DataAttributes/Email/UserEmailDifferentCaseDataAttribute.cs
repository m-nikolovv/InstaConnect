using InstaConnect.Common.Tests.Features.DataAttributes.Strings.DifferentCase;

namespace InstaConnect.Follows.Tests.Features.Users.DataAttributes.Email;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserEmailDifferentCaseDataAttribute : DifferentCaseStringDataAttribute
{
}
