namespace InstaConnect.Chats.Infrastructure.Features.Chats.Helpers.Includers;

internal class ChatIncluderFactory
	: IncluderFactory<ChatsIncludeType, ChatsDestinationType, ChatsIncludeDescriptor, IChatIncluder, Chat>, IChatIncluderFactory
{
	public ChatIncluderFactory(IEnumerable<IChatIncluder> includers) : base(includers)
	{
	}
}
