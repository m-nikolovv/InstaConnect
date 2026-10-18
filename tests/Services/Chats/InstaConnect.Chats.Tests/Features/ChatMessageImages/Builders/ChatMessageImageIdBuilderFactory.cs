using InstaConnect.Chats.Domain.Features.ChatMessageImages.Models.ValueObjects;

namespace InstaConnect.Chats.Tests.Features.ChatMessageImages.Builders;

public class ChatMessageImageIdBuilderFactory
{
	public ChatMessageImageIdBuilder Create(ChatMessageImageId id)
	{
		return new(id);
	}
}
