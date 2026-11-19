namespace InstaConnect.Chats.Infrastructure.Features.Chats.Helpers.Includers;

internal class ChatMessagesIncluder : IChatIncluder
{
	private readonly IMongoCollection<ChatMessage> _collection;

	public ChatMessagesIncluder(IMongoCollection<ChatMessage> collection)
	{
		_collection = collection;
	}

	public ChatsDestinationType DestinationType => ChatsDestinationType.Chat;

	public ChatsIncludeType IncludeType => ChatsIncludeType.ChatMessage;

	public IAggregateFluent<Chat> Include(IAggregateFluent<Chat> aggregate)
	{
		return aggregate
			.IncludeMany(
				_collection,
				p => p.Id,
				m => m.Id.Id,
				p => p.ChatMessages
			);
	}
}
