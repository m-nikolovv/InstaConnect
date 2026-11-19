namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Helpers.Collections;

internal class ChatMessageCollectionInitializer : MongoDbCollectionInitializer<ChatMessage>
{
	public ChatMessageCollectionInitializer(IMongoCollection<ChatMessage> collection)
		: base(
			collection,
			[
				Builders<ChatMessage>.IndexKeys.Ascending(c => c.Id.Id.ParticipantOneId.Id).Ascending(c => c.Id.Id.ParticipantTwoId.Id).Ascending(c => c.CreatedAtUtc).ToIndex(),
				Builders<ChatMessage>.IndexKeys.Ascending(c => c.SenderId).ToIndex(),
				Builders<ChatMessage>.IndexKeys.Ascending(c => c.Id.Id).ToIndex()
			])
	{
	}
}
