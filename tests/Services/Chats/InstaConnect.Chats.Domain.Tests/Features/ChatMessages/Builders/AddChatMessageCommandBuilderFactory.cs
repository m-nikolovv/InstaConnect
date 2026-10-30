namespace InstaConnect.Chats.Domain.Tests.Features.ChatMessages.Builders;

public class AddChatMessageCommandBuilderFactory
{
	public AddChatMessageCommandBuilder Create(Chat chat)
	{
		return new(chat);
	}
}
