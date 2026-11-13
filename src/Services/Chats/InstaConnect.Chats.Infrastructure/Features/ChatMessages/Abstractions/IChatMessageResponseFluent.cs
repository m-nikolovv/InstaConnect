namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Abstractions;

public interface IChatMessageResponseFluent : IMongoDbResponseFluent<ChatMessageResponse>
{
	public IChatMessageResponseFluent Sort(ChatMessagesSortingQuery query);
	public IChatMessageResponseFluent Paginate(ChatMessagesPaginationQuery query);
}
