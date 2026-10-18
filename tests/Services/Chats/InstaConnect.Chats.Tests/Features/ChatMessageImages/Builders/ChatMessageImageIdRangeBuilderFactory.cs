using InstaConnect.Chats.Domain.Features.ChatMessageImages.Models.ValueObjects;

namespace InstaConnect.Chats.Tests.Features.ChatMessageImages.Builders;

public class ChatMessageImageIdRangeBuilderFactory
{
	private readonly ChatMessageImageIdBuilderFactory _idBuilderFactory;

	public ChatMessageImageIdRangeBuilderFactory()
	{
		_idBuilderFactory = new();
	}

	public ChatMessageImageIdRangeBuilder Create(ICollection<ChatMessageImageId> ids)
	{
		return new([.. ids.Select(_idBuilderFactory.Create)]);
	}
}
