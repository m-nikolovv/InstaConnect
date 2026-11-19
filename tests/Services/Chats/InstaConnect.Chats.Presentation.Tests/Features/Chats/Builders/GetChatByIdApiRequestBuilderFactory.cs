namespace InstaConnect.Chats.Presentation.Tests.Features.Chats.Builders;

public class GetChatByIdApiRequestBuilderFactory
{
	public GetChatByIdApiRequestBuilder Create(Chat chat, UserId currentUserId)
	{
		return new(chat, currentUserId);
	}
}
