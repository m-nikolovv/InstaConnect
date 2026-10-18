namespace InstaConnect.Chats.Presentation.Tests.Features.ChatMessages.Builders;

public class AddChatMessageApiRequestBuilderFactory
{
	public AddChatMessageApiRequestBuilder Create(Chat chat, int numberOfImages)
	{
		return new(chat, numberOfImages);
	}
}
