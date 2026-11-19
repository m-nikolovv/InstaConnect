namespace InstaConnect.Chats.Infrastructure.Features.ChatMessageImages.Abstractions;

public interface IChatMessageImageFluent : IMongoDbFluent<ChatMessageImage, ChatMessageImageId>
{
	public IChatMessageImageFluent Match(ChatMessageImageId filter);

	public IChatMessageImageFluent Match(IEnumerable<ChatMessageImageId> filter);
}
