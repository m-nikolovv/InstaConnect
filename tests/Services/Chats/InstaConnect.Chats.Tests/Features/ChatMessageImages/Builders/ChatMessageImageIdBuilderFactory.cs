namespace InstaConnect.Chats.Tests.Features.ChatMessageImages.Builders;

public class ChatMessageImageIdBuilderFactory
{
	public ChatMessageImageIdBuilder Create(ChatMessageImageId id)
	{
		return new(id);
	}
}
