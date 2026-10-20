namespace InstaConnect.Chats.Domain.Features.Users.Abstractions;

public interface IParticipantOneIncludeDescriptorFactory
{
	public ChatsIncludeDescriptor CreateChatMessages();
	public ChatsIncludeDescriptor CreateChats();
}
