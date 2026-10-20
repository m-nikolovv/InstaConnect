namespace InstaConnect.Chats.Domain.Features.Users.Helpers;

public class ParticipantTwoIncludeDescriptorFactory : IParticipantTwoIncludeDescriptorFactory
{
	public ChatsIncludeDescriptor CreateChats()
	{
		return new(ChatsDestinationType.ParticipantTwo, ChatsIncludeType.Chat);
	}

	public ChatsIncludeDescriptor CreateChatMessages()
	{
		return new(ChatsDestinationType.ParticipantTwo, ChatsIncludeType.ChatMessage);
	}
}
