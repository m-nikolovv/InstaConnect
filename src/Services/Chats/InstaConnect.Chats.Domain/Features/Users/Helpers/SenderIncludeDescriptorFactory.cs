namespace InstaConnect.Chats.Domain.Features.Users.Helpers;

public class SenderIncludeDescriptorFactory : ISenderIncludeDescriptorFactory
{
	public ChatsIncludeDescriptor CreateChats()
	{
		return new(ChatsDestinationType.Sender, ChatsIncludeType.Chat);
	}

	public ChatsIncludeDescriptor CreateChatMessages()
	{
		return new(ChatsDestinationType.Sender, ChatsIncludeType.ChatMessage);
	}
}
