namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Helpers.Includers;

internal class SenderIncluder : IChatMessageIncluder
{
	private readonly IMongoCollection<User> _collection;

	public SenderIncluder(IMongoCollection<User> collection)
	{
		_collection = collection;
	}

	public ChatsDestinationType DestinationType => ChatsDestinationType.ChatMessage;

	public ChatsIncludeType IncludeType => ChatsIncludeType.Sender;

	public IAggregateFluent<ChatMessage> Include(IAggregateFluent<ChatMessage> aggregate)
	{
		return aggregate
			.IncludeOne(
				_collection,
				p => p.SenderId,
				u => u.Id,
				p => p.Sender!
			);
	}
}
