namespace InstaConnect.Chats.Domain.Features.Users.Helpers;

public class ParticipantOneIncludeDescriptorFactory : IParticipantOneIncludeDescriptorFactory
{
	public ChatsIncludeDescriptor CreateChats()
	{
		return new(ChatsDestinationType.ParticipantOne, ChatsIncludeType.Chat);
	}

	public ChatsIncludeDescriptor CreateChatMessages()
	{
		return new(ChatsDestinationType.ParticipantOne, ChatsIncludeType.ChatMessage);
	}
}
