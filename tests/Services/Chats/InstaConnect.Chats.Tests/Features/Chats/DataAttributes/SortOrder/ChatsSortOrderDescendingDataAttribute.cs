namespace InstaConnect.Chats.Tests.Features.Chats.DataAttributes.SortOrder;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class ChatsSortOrderDescendingDataAttribute : SortEnumDataAttribute<CommonSortOrder>
{
	public ChatsSortOrderDescendingDataAttribute()
		: base(CommonSortOrder.Descending)
	{
	}
}
