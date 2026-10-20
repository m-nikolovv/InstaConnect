namespace InstaConnect.Posts.Tests.Features.Posts.DataAttributes.SortOrder;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostsSortOrderEmptyDataAttribute : EmptyEnumDataAttribute<CommonSortOrder>;
