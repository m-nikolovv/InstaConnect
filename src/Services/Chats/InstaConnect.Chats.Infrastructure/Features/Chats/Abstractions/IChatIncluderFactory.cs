namespace InstaConnect.Chats.Infrastructure.Features.Chats.Abstractions;

public interface IChatIncluderFactory
	: IIncluderFactory<ChatsIncludeType, ChatsDestinationType, ChatsIncludeDescriptor, IChatIncluder, Chat>;

