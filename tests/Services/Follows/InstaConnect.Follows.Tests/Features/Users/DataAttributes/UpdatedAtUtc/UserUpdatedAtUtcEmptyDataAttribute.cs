using InstaConnect.Common.Tests.Features.DataAttributes.DateTimeOffsets.Empty;

namespace InstaConnect.Follows.Tests.Features.Users.DataAttributes.UpdatedAtUtc;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserUpdatedAtUtcEmptyDataAttribute : EmptyDateTimeOffsetDataAttribute;
