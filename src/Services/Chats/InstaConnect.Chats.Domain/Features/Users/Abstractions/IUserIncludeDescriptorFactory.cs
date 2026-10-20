namespace InstaConnect.Chats.Domain.Features.Users.Abstractions;

public interface IUserIncludeDescriptorFactory
{
	public ChatsIncludeDescriptor CreateChats();

	public ChatsIncludeDescriptor CreateChatMessages();
}
