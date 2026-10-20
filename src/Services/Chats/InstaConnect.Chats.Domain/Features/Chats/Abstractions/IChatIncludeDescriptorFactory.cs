namespace InstaConnect.Chats.Domain.Features.Chats.Abstractions;

public interface IChatIncludeDescriptorFactory
{
	public ChatsIncludeDescriptor CreateParticipantOne();
	public ChatsIncludeDescriptor CreateParticipantTwo();
}
