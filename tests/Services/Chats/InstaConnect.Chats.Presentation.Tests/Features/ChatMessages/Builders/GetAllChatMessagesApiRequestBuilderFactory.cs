namespace InstaConnect.Chats.Presentation.Tests.Features.ChatMessages.Builders;

public class GetAllChatMessagesApiRequestBuilderFactory
{
	public GetAllChatMessagesApiRequestBuilder Create(ChatMessage chatMessage, UserId currentUserId)
	{
		return new(chatMessage, currentUserId);
	}
}
