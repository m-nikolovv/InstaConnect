namespace InstaConnect.Chats.Infrastructure.Features.ChatMessageImages.Helpers.Collections;

internal class ChatMessageImageCollectionInitializer : MongoDbCollectionInitializer<ChatMessageImage>
{
	public ChatMessageImageCollectionInitializer(IMongoCollection<ChatMessageImage> collection)
		: base(
			collection,
			[
				Builders<ChatMessageImage>.IndexKeys.Ascending(c => c.Id.Id.Id.ParticipantOneId.Id).Ascending(c => c.Id.Id.Id.ParticipantTwoId.Id).Ascending(c => c.Id.Id.MessageId).ToIndex(),
				Builders<ChatMessageImage>.IndexKeys.Ascending(c => c.Id.Id).ToIndex()
			])
	{
	}
}
