namespace InstaConnect.Chats.Infrastructure.Tests.Features.Chats.Builders;

public class ChatsFilterQueryBuilderFactory
{
	public ChatsFilterQueryBuilder Create(Chat chat)
	{
		return new(chat);
	}
}
