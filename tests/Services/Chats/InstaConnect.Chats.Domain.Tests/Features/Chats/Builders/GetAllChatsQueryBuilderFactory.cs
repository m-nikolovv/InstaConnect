namespace InstaConnect.Chats.Domain.Tests.Features.Chats.Builders;

public class GetAllChatsQueryBuilderFactory
{
	public GetAllChatsQueryBuilder Create(Chat chat, UserId currentUserId)
	{
		return new(chat, currentUserId);
	}
}
