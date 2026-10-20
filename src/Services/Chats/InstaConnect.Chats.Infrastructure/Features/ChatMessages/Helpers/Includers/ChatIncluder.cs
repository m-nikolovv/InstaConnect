namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Helpers.Includers;

internal class ChatIncluder : IChatMessageIncluder
{
	private readonly IMongoCollection<Chat> _collection;

	public ChatIncluder(IMongoCollection<Chat> collection)
	{
		_collection = collection;
	}

	public ChatsDestinationType DestinationType => ChatsDestinationType.ChatMessage;

	public ChatsIncludeType IncludeType => ChatsIncludeType.Chat;

	public IAggregateFluent<ChatMessage> Include(IAggregateFluent<ChatMessage> aggregate)
	{
		return aggregate
			.IncludeOne(
				_collection,
				p => p.Id.Id,
				u => u.Id,
				p => p.Chat!
			);
	}
}
