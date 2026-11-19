namespace InstaConnect.Chats.Domain.Tests.Features.Chats.Builders;

public class GetChatByIdQueryBuilderFactory
{
	public GetChatByIdQueryBuilder Create(Chat chat, UserId currentUserId)
	{
		return new(chat, currentUserId);
	}
}
