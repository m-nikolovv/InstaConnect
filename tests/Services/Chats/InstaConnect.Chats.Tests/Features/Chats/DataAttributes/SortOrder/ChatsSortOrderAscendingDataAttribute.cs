namespace InstaConnect.Chats.Tests.Features.Chats.DataAttributes.SortOrder;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class ChatsSortOrderAscendingDataAttribute : SortEnumDataAttribute<CommonSortOrder>
{
	public ChatsSortOrderAscendingDataAttribute()
		: base(CommonSortOrder.Ascending)
	{
	}
}
