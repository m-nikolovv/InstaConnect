namespace InstaConnect.Chats.Infrastructure.Features.Chats.Helpers.Includers;

internal class ParticipantOneIncluder : IChatIncluder
{
	private readonly IMongoCollection<User> _collection;

	public ParticipantOneIncluder(IMongoCollection<User> collection)
	{
		_collection = collection;
	}

	public ChatsDestinationType DestinationType => ChatsDestinationType.Chat;

	public ChatsIncludeType IncludeType => ChatsIncludeType.ParticipantOne;

	public IAggregateFluent<Chat> Include(IAggregateFluent<Chat> aggregate)
	{
		return aggregate
			.IncludeOne(
				_collection,
				p => p.Id.ParticipantOneId,
				u => u.Id,
				p => p.ParticipantOne!
			);
	}
}
