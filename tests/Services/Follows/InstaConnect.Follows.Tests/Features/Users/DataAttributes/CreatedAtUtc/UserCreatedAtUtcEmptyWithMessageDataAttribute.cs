using InstaConnect.Common.Tests.Features.DataAttributes.DateTimeOffsets.Empty;

namespace InstaConnect.Follows.Tests.Features.Users.DataAttributes.CreatedAtUtc;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserCreatedAtUtcEmptyWithMessageDataAttribute : EmptyDateTimeOffsetWithMessageDataAttribute;
