using InstaConnect.Common.Tests.Features.DataAttributes.Strings.InvalidEmail;

namespace InstaConnect.Identity.Tests.Features.Users.DataAttributes.Email;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserEmailInvalidDataAttribute : InvalidEmailStringDataAttribute
{
}
