namespace InstaConnect.Chats.Domain.Features.Users.Models.Requests;

public record UserInclude(ICollection<ChatsIncludeDescriptor> Descriptors)
	: Include<ChatsDestinationType, ChatsIncludeType, ChatsIncludeDescriptor>(Descriptors);
