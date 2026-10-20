namespace InstaConnect.Chats.Tests.Features.ChatMessages.Builders;

public class ChatMessageIdRangeBuilderFactory
{
	private readonly ChatMessageIdBuilderFactory _idBuilderFactory;

	public ChatMessageIdRangeBuilderFactory()
	{
		_idBuilderFactory = new();
	}

	public ChatMessageIdRangeBuilder Create(ICollection<ChatMessageId> ids)
	{
		return new([.. ids.Select(_idBuilderFactory.Create)]);
	}
}
