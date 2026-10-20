namespace InstaConnect.Chats.Tests.Features.ChatMessages.Builders;

public class ChatMessageBuilderFactory
{
	public ChatMessageBuilder Create(Chat chat)
	{
		return new(chat);
	}

	public ChatMessageBuilder Create(ChatMessage chatMessage)
	{
		return new(chatMessage);
	}
}
