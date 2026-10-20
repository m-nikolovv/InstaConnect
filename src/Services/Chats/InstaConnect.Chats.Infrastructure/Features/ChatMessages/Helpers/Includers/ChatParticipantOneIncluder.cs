namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Helpers.Includers;

internal class ChatParticipantOneIncluder : IChatMessageIncluder
{
	private readonly IMongoCollection<User> _collection;

	public ChatParticipantOneIncluder(IMongoCollection<User> collection)
	{
		_collection = collection;
	}

	public ChatsDestinationType DestinationType => ChatsDestinationType.Chat;

	public ChatsIncludeType IncludeType => ChatsIncludeType.ParticipantOne;

	public IAggregateFluent<ChatMessage> Include(IAggregateFluent<ChatMessage> aggregate)
	{
		return aggregate
			.IncludeOne(
				_collection,
				p => p.Id.Id.ParticipantOneId,
				u => u.Id,
				p => p.Chat!.ParticipantOne!
			);
	}
}
