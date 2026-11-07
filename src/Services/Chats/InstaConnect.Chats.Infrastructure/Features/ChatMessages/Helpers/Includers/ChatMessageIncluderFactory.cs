namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Helpers.Includers;

internal class ChatMessageIncluderFactory
	: IncluderFactory<ChatsIncludeType, ChatsDestinationType, ChatsIncludeDescriptor, IChatMessageIncluder, ChatMessage>, IChatMessageIncluderFactory
{
	public ChatMessageIncluderFactory(IEnumerable<IChatMessageIncluder> includers) : base(includers)
	{
	}
}
