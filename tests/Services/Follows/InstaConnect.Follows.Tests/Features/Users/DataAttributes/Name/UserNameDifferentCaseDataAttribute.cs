namespace InstaConnect.Follows.Tests.Features.Users.DataAttributes.Name;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserNameDifferentCaseDataAttribute : DifferentCaseStringDataAttribute
{
}
