namespace InstaConnect.Chats.Presentation.Tests.Features.Chats.Builders;

public class GetAllChatsApiRequestBuilderFactory
{
	public GetAllChatsApiRequestBuilder Create(Chat chat, UserId currentUserId)
	{
		return new(chat, currentUserId);
	}
}
