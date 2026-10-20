namespace InstaConnect.Chats.Tests.Features.Chats.DataAttributes.SortOrder;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class ChatsSortOrderWithAscendingTermDataAttribute
	: SortEnumWithAscendingTermDataAttribute<CommonSortOrder, Chat, DateTimeOffset>
{
	public ChatsSortOrderWithAscendingTermDataAttribute()
		: base(CommonSortOrder.Ascending, p => p.CreatedAtUtc)
	{
	}
}
