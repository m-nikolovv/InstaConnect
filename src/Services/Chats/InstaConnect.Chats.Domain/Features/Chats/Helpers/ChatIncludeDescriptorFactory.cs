namespace InstaConnect.Chats.Domain.Features.Chats.Helpers;

public class ChatIncludeDescriptorFactory : IChatIncludeDescriptorFactory
{
	public ChatsIncludeDescriptor CreateParticipantOne()
	{
		return new(ChatsDestinationType.Chat, ChatsIncludeType.ParticipantOne);
	}

	public ChatsIncludeDescriptor CreateParticipantTwo()
	{
		return new(ChatsDestinationType.Chat, ChatsIncludeType.ParticipantTwo);
	}
}
