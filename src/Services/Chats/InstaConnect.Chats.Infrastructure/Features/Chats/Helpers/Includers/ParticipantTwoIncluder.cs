namespace InstaConnect.Chats.Infrastructure.Features.Chats.Helpers.Includers;

internal class ParticipantTwoIncluder : IChatIncluder
{
	private readonly IMongoCollection<User> _collection;

	public ParticipantTwoIncluder(IMongoCollection<User> collection)
	{
		_collection = collection;
	}

	public ChatsDestinationType DestinationType => ChatsDestinationType.Chat;

	public ChatsIncludeType IncludeType => ChatsIncludeType.ParticipantTwo;

	public IAggregateFluent<Chat> Include(IAggregateFluent<Chat> aggregate)
	{
		return aggregate
			.IncludeOne(
				_collection,
				p => p.Id.ParticipantTwoId,
				u => u.Id,
				p => p.ParticipantTwo!
			);
	}
}
