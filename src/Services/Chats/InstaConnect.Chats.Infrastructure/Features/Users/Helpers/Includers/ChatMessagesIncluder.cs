namespace InstaConnect.Chats.Infrastructure.Features.Users.Helpers.Includers;

internal class ChatMessagesIncluder : IUserIncluder
{
	private readonly IMongoCollection<ChatMessage> _collection;

	public ChatMessagesIncluder(IMongoCollection<ChatMessage> collection)
	{
		_collection = collection;
	}

	public ChatsDestinationType DestinationType => ChatsDestinationType.User;

	public ChatsIncludeType IncludeType => ChatsIncludeType.ChatMessage;

	public IAggregateFluent<User> Include(IAggregateFluent<User> aggregate)
	{
		return aggregate
			.IncludeMany(
				_collection,
				p => p.Id,
				l => l.SenderId,
				p => p.ChatMessages
			);
	}
}
