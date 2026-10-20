namespace InstaConnect.Chats.Domain.Features.ChatMessages.Models.Entities;

public class ChatMessage : IEntityWithId<ChatMessageId>
{
	private ChatMessage()
	{
		Id = new(new(new(string.Empty), new(string.Empty)), string.Empty);
		SenderId = new(string.Empty);
		Content = string.Empty;
		Summary = new(string.Empty);
		ChatMessageImages = [];
	}

	public ChatMessage(
		ChatMessageId id,
		UserId senderId,
		string content,
		Summary summary,
		DateTimeOffset createdAtUtc,
		DateTimeOffset updatedAtUtc)
	{
		Id = id;
		SenderId = senderId;
		Content = content;
		Summary = summary;
		ChatMessageImages = [];
		CreatedAtUtc = createdAtUtc;
		UpdatedAtUtc = updatedAtUtc;
	}

	public ChatMessageId Id { get; }

	public UserId SenderId { get; }

	public User? Sender { get; private set; }

	public Chat? Chat { get; private set; }

	public string Content { get; private set; }

	public Summary Summary { get; private set; }

	public ICollection<ChatMessageImage> ChatMessageImages { get; private set; }

	public DateTimeOffset CreatedAtUtc { get; }

	public DateTimeOffset UpdatedAtUtc { get; private set; }

	public void Update(string content, DateTimeOffset updatedAtUtc)
	{
		Content = content;
		UpdatedAtUtc = updatedAtUtc;
	}

	public void UpdateSummary(Summary summary)
	{
		Summary = summary;
	}

	public ChatMessage AddSender(User? sender)
	{
		Sender = sender;

		return this;
	}

	public ChatMessage AddChat(Chat? chat)
	{
		Chat = chat;

		return this;
	}

	public ChatMessage AddChatMessageImage(ChatMessageImage chatMessageImage)
	{
		ChatMessageImages.Add(chatMessageImage);

		return this;
	}

	public ChatMessage AddChatMessageImages(ICollection<ChatMessageImage> chatMessageImages)
	{
		ChatMessageImages.AddRange(chatMessageImages);

		return this;
	}
}
