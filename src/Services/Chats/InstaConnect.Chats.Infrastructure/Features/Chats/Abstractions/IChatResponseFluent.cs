namespace InstaConnect.Chats.Infrastructure.Features.Chats.Abstractions;

public interface IChatResponseFluent : IMongoDbResponseFluent<ChatResponse>
{
	public IChatResponseFluent Sort(ChatsSortingQuery query);
	public IChatResponseFluent Paginate(ChatsPaginationQuery query);
}
