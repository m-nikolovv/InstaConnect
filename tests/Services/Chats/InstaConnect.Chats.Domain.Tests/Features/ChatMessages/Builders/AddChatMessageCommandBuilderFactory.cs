namespace InstaConnect.Chats.Domain.Tests.Features.ChatMessages.Builders;

public class AddChatMessageCommandBuilderFactory
{
	public AddChatMessageCommandBuilder Create(Chat chat, int numberOfImages)
	{
		return new(chat, numberOfImages);
	}
}
