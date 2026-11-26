namespace InstaConnect.Chats.Infrastructure.Features.Chats.Helpers.Collections;

internal class ChatCollectionInitializer : MongoDbCollectionInitializer<Chat>
{
	public ChatCollectionInitializer(IMongoCollection<Chat> collection)
		: base(
			collection,
			[
				Builders<Chat>.IndexKeys.Ascending(c => c.Id.ParticipantOneId.Id).Ascending(c => c.CreatedAtUtc).ToIndex(),
				Builders<Chat>.IndexKeys.Ascending(c => c.Id.ParticipantTwoId.Id).Ascending(c => c.CreatedAtUtc).ToIndex(),
				Builders<Chat>.IndexKeys.Ascending(c => c.Id.ParticipantOneId).ToIndex(),
				Builders<Chat>.IndexKeys.Ascending(c => c.Id.ParticipantTwoId).ToIndex()
			])
	{
	}
}
