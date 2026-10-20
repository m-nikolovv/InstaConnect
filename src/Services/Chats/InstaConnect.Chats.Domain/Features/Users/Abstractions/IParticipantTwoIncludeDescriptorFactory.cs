namespace InstaConnect.Chats.Domain.Features.Users.Abstractions;

public interface IParticipantTwoIncludeDescriptorFactory
{
	public ChatsIncludeDescriptor CreateChatMessages();
	public ChatsIncludeDescriptor CreateChats();
}
