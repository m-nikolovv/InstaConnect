namespace InstaConnect.Chats.Domain.Features.ChatMessageImages.Models.Entities;

public class ChatMessageImage : IEntityWithId<ChatMessageImageId>
{
	private ChatMessageImage()
	{
		Id = new(new(new(new(string.Empty), new(string.Empty)), string.Empty), string.Empty);
		Url = new(string.Empty);
	}

	public ChatMessageImage(
		ChatMessageImageId id,
		Url url,
		DateTimeOffset createdAtUtc)
	{
		Id = id;
		Url = url;
		CreatedAtUtc = createdAtUtc;
	}

	public ChatMessageImageId Id { get; }

	public Url Url { get; }

	public ChatMessage? ChatMessage { get; private set; }

	public DateTimeOffset CreatedAtUtc { get; }

	public ChatMessageImage AddChatMessage(ChatMessage? chatMessage)
	{
		ChatMessage = chatMessage;

		return this;
	}
}
