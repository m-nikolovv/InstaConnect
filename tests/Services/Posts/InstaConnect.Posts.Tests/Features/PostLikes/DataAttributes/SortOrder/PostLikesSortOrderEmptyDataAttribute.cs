namespace InstaConnect.Posts.Tests.Features.PostLikes.DataAttributes.SortOrder;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostLikesSortOrderEmptyDataAttribute : EmptyEnumDataAttribute<CommonSortOrder>;
