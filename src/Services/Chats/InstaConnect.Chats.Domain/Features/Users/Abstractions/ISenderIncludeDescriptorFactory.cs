namespace InstaConnect.Chats.Domain.Features.Users.Abstractions;

public interface ISenderIncludeDescriptorFactory
{
	public ChatsIncludeDescriptor CreateChatMessages();
	public ChatsIncludeDescriptor CreateChats();
}
