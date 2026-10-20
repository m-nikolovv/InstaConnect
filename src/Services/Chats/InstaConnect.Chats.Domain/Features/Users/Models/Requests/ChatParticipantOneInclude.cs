namespace InstaConnect.Chats.Domain.Features.Users.Models.Requests;

public record ChatParticipantOneInclude(ICollection<ChatsIncludeDescriptor> Descriptors)
	: Include<ChatsDestinationType, ChatsIncludeType, ChatsIncludeDescriptor>(Descriptors);
