namespace InstaConnect.Chats.Infrastructure.Features.Chats.Helpers.Collections;

internal class ChatCollectionInitializer : MongoDbCollectionInitializer<Chat>
{
	public ChatCollectionInitializer(IMongoCollection<Chat> collection)
		: base(
			collection,
			[
				new(Builders<Chat>.IndexKeys.Ascending(c => c.Id.ParticipantOneId.Id).Ascending(c => c.CreatedAtUtc)),
				new(Builders<Chat>.IndexKeys.Ascending(c => c.Id.ParticipantTwoId.Id).Ascending(c => c.CreatedAtUtc)),
				new(Builders<Chat>.IndexKeys.Ascending(c => c.Id.ParticipantOneId)),
				new(Builders<Chat>.IndexKeys.Ascending(c => c.Id.ParticipantTwoId))
			])
	{
	}
}
