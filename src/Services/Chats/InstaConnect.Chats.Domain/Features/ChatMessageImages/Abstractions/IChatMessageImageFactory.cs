namespace InstaConnect.Chats.Domain.Features.ChatMessageImages.Abstractions;

public interface IChatMessageImageFactory
{
	public ICollection<ChatMessageImage> CreateRange(ChatMessageId id, ICollection<Url> urls);
}
