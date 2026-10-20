namespace InstaConnect.Chats.Tests.Features.ChatMessages.Builders;

public class ChatMessageIdBuilderFactory
{
	public ChatMessageIdBuilder Create(ChatMessageId id)
	{
		return new(id);
	}
}
