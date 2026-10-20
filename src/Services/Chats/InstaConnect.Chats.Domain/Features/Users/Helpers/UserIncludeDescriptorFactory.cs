namespace InstaConnect.Chats.Domain.Features.Users.Helpers;

public class UserIncludeDescriptorFactory : IUserIncludeDescriptorFactory
{
	public ChatsIncludeDescriptor CreateChats()
	{
		return new(ChatsDestinationType.User, ChatsIncludeType.Chat);
	}

	public ChatsIncludeDescriptor CreateChatMessages()
	{
		return new(ChatsDestinationType.User, ChatsIncludeType.ChatMessage);
	}
}
