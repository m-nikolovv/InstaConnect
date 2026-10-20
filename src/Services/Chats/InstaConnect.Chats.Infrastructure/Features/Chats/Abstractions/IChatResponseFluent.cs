namespace InstaConnect.Chats.Infrastructure.Features.Chats.Abstractions;

public interface IChatResponseFluent : IMongoDbResponseFluent<ChatResponse>
{
	public IChatResponseFluent ApplySorting(ChatsSortingQuery query);
	public IChatResponseFluent ApplyPagination(ChatsPaginationQuery query);
}
