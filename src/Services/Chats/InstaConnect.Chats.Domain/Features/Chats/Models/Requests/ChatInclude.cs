namespace InstaConnect.Chats.Domain.Features.Chats.Models.Requests;

public record ChatInclude(ICollection<ChatsIncludeDescriptor> Descriptors)
	: Include<ChatsDestinationType, ChatsIncludeType, ChatsIncludeDescriptor>(Descriptors);
