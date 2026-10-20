namespace InstaConnect.Chats.Tests.Features.Chats.Builders;

public class ChatIdRangeBuilderFactory
{
	private readonly ChatIdBuilderFactory _idBuilderFactory;

	public ChatIdRangeBuilderFactory()
	{
		_idBuilderFactory = new();
	}

	public ChatIdRangeBuilder Create(ICollection<ChatId> ids)
	{
		return new([.. ids.Select(_idBuilderFactory.Create)]);
	}
}
