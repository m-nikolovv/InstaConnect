namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Helpers.SortTermers;

internal class ByCreatedAtSortTermer : IChatMessagesSortTermer
{
	public ChatMessagesSortTerm SortTerm => ChatMessagesSortTerm.ByCreatedAt;

	public Expression<Func<ChatMessage, object>> Term => p => p.CreatedAtUtc;
}
