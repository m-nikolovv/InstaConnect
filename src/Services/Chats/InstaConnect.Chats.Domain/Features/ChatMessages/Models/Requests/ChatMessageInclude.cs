namespace InstaConnect.Chats.Domain.Features.ChatMessages.Models.Requests;

public record ChatMessageInclude(ICollection<ChatsIncludeDescriptor> Descriptors)
	: Include<ChatsDestinationType, ChatsIncludeType, ChatsIncludeDescriptor>(Descriptors);
