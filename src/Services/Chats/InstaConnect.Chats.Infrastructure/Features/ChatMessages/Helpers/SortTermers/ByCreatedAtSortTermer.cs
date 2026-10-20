namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Helpers.SortTermers;

internal class ByCreatedAtSortTermer : IChatMessagesSortTermer
{
	public ChatMessagesSortTerm SortTerm => ChatMessagesSortTerm.ByCreatedAt;

	public Expression<Func<ChatMessageResponse, object>> Term => p => p.CreatedAtUtc;
}
