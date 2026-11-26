namespace InstaConnect.Chats.Domain.Tests.Features.ChatMessages.Builders;

public class GetChatMessageByIdQueryBuilderFactory
{
	public GetChatMessageByIdQueryBuilder Create(ChatMessage chatMessage, UserId currentUserId)
	{
		return new(chatMessage, currentUserId);
	}
}
