namespace InstaConnect.Chats.Tests.Features.ChatMessageImages.Builders;

public class ChatMessageImageBuilderFactory
{
	public ChatMessageImageBuilder Create(ChatMessage chatMessage)
	{
		return new(chatMessage);
	}

	public ChatMessageImageBuilder Create(ChatMessageImage chatMessageImage)
	{
		return new(chatMessageImage);
	}
}
