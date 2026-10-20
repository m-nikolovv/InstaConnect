namespace InstaConnect.Follows.Tests.Features.Users.DataAttributes.Id;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserIdDifferentCaseDataAttribute : DifferentCaseStringDataAttribute
{
}
