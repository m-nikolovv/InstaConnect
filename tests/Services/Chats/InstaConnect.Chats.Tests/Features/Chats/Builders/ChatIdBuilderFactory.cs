namespace InstaConnect.Chats.Tests.Features.Chats.Builders;

public class ChatIdBuilderFactory
{
	public ChatIdBuilder Create(ChatId id)
	{
		return new(id);
	}
}
