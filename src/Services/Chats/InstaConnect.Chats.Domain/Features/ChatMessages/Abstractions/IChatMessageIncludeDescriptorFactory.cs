namespace InstaConnect.Chats.Domain.Features.ChatMessages.Abstractions;

public interface IChatMessageIncludeDescriptorFactory
{
	public ChatsIncludeDescriptor CreateChat();
	public ChatsIncludeDescriptor CreateSender();
	public ChatsIncludeDescriptor CreateChatMessageImages();
}
