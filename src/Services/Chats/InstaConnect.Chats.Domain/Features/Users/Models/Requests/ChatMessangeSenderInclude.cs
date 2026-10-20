namespace InstaConnect.Chats.Domain.Features.Users.Models.Requests;

public record ChatMessangeSenderInclude(ICollection<ChatsIncludeDescriptor> Descriptors)
	: Include<ChatsDestinationType, ChatsIncludeType, ChatsIncludeDescriptor>(Descriptors);
