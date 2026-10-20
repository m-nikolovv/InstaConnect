namespace InstaConnect.Follows.Tests.Features.Follows.DataAttributes.SortOrder;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class FollowsSortOrderEmptyDataAttribute : EmptyEnumDataAttribute<CommonSortOrder>;
