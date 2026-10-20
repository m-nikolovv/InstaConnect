namespace InstaConnect.Chats.Infrastructure.Tests.Features.ChatMessages.Builders;

public class ChatMessagesFilterQueryBuilderFactory
{
	public ChatMessagesFilterQueryBuilder Create(ChatMessage chatMessage)
	{
		return new(chatMessage);
	}
}
