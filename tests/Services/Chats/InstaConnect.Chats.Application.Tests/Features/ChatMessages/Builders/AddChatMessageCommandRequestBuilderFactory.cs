namespace InstaConnect.Chats.Application.Tests.Features.ChatMessages.Builders;

public class AddChatMessageCommandRequestBuilderFactory
{
	public AddChatMessageCommandRequestBuilder Create(Chat chat)
	{
		return new(chat);
	}
}
