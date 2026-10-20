namespace InstaConnect.Chats.Infrastructure.Features.Users.Helpers.Includers;

internal class ChatsIncluder : IUserIncluder
{
	private readonly IMongoCollection<Chat> _collection;

	public ChatsIncluder(IMongoCollection<Chat> collection)
	{
		_collection = collection;
	}

	public ChatsDestinationType DestinationType => ChatsDestinationType.User;

	public ChatsIncludeType IncludeType => ChatsIncludeType.Chat;

	public IAggregateFluent<User> Include(IAggregateFluent<User> aggregate)
	{
		return aggregate
			.IncludeMany(
				_collection,
				p => p.Id,
				l => l.Id.ParticipantOneId,
				p => p.Chats
			)
			.IncludeMany(
				_collection,
				p => p.Id,
				l => l.Id.ParticipantTwoId,
				p => p.Chats
			);
	}
}
