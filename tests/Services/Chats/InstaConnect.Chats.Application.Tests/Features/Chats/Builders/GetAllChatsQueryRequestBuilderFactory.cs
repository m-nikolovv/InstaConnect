namespace InstaConnect.Chats.Application.Tests.Features.Chats.Builders;

public class GetAllChatsQueryRequestBuilderFactory
{
	public GetAllChatsQueryRequestBuilder Create(Chat chat, UserId currentUserId)
	{
		return new(chat, currentUserId);
	}
}
