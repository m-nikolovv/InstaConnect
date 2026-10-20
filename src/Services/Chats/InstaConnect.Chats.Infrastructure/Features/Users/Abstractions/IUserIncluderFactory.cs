namespace InstaConnect.Chats.Infrastructure.Features.Users.Abstractions;

public interface IUserIncluderFactory
	: IIncluderFactory<ChatsIncludeType, ChatsDestinationType, ChatsIncludeDescriptor, IUserIncluder, User>;
