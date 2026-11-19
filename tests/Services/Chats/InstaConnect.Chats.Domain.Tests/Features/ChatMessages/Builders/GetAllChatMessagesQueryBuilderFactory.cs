namespace InstaConnect.Chats.Domain.Tests.Features.ChatMessages.Builders;

public class GetAllChatMessagesQueryBuilderFactory
{
	public GetAllChatMessagesQueryBuilder Create(ChatMessage chatMessage, UserId currentUserId)
	{
		return new(chatMessage, currentUserId);
	}
}
