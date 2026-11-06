namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Helpers.Collections;

internal class ChatMessageCollectionInitializer : MongoDbCollectionInitializer<ChatMessage>
{
	public ChatMessageCollectionInitializer(IMongoCollection<ChatMessage> collection)
		: base(
			collection,
			[
				new(Builders<ChatMessage>.IndexKeys.Ascending(c => c.Id.Id.ParticipantOneId.Id).Ascending(c => c.Id.Id.ParticipantTwoId.Id).Ascending(c => c.CreatedAtUtc)),
				new(Builders<ChatMessage>.IndexKeys.Ascending(c => c.SenderId)),
				new(Builders<ChatMessage>.IndexKeys.Ascending(c => c.Id.Id))
			])
	{
	}
}
