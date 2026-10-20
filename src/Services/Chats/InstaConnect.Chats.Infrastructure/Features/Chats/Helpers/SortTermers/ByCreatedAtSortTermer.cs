namespace InstaConnect.Chats.Infrastructure.Features.Chats.Helpers.SortTermers;

internal class ByCreatedAtSortTermer : IChatsSortTermer
{
	public ChatsSortTerm SortTerm => ChatsSortTerm.ByCreatedAt;

	public Expression<Func<ChatResponse, object>> Term => p => p.CreatedAtUtc;
}
