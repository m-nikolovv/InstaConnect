namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Abstractions;

public interface IChatMessageIncluderFactory
	: IIncluderFactory<ChatsIncludeType, ChatsDestinationType, ChatsIncludeDescriptor, IChatMessageIncluder, ChatMessage>;
