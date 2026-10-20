using InstaConnect.Common.Tests.Features.DataAttributes.Strings.InvalidEmail;

namespace InstaConnect.Chats.Tests.Features.Users.DataAttributes.Email;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserEmailInvalidDataAttribute : InvalidEmailStringDataAttribute
{
}
