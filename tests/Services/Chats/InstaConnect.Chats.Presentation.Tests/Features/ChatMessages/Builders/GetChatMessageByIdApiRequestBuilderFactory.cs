namespace InstaConnect.Chats.Presentation.Tests.Features.ChatMessages.Builders;

public class GetChatMessageByIdApiRequestBuilderFactory
{
	public GetChatMessageByIdApiRequestBuilder Create(ChatMessage chatMessage, UserId currentUserId)
	{
		return new(chatMessage, currentUserId);
	}
}
