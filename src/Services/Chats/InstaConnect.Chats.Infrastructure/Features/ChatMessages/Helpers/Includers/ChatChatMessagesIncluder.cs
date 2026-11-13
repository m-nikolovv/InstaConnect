namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Helpers.Includers;

internal class ChatChatMessagesIncluder : IChatMessageIncluder
{
	private readonly IMongoCollection<ChatMessage> _collection;

	public ChatChatMessagesIncluder(IMongoCollection<ChatMessage> collection)
	{
		_collection = collection;
	}

	public ChatsDestinationType DestinationType => ChatsDestinationType.Chat;

	public ChatsIncludeType IncludeType => ChatsIncludeType.ChatMessage;

	public IAggregateFluent<ChatMessage> Include(IAggregateFluent<ChatMessage> aggregate)
	{
		return aggregate
			.IncludeMany(
				_collection,
				p => p.Id.Id,
				m => m.Id.Id,
				p => p.Chat!.ChatMessages
			);
	}
}
