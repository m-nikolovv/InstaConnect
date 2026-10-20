namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Helpers.Includers;

internal class ChatParticipantTwoIncluder : IChatMessageIncluder
{
	private readonly IMongoCollection<User> _collection;

	public ChatParticipantTwoIncluder(IMongoCollection<User> collection)
	{
		_collection = collection;
	}

	public ChatsDestinationType DestinationType => ChatsDestinationType.Chat;

	public ChatsIncludeType IncludeType => ChatsIncludeType.ParticipantTwo;

	public IAggregateFluent<ChatMessage> Include(IAggregateFluent<ChatMessage> aggregate)
	{
		return aggregate
			.IncludeOne(
				_collection,
				p => p.Id.Id.ParticipantTwoId,
				u => u.Id,
				p => p.Chat!.ParticipantTwo!
			);
	}
}
