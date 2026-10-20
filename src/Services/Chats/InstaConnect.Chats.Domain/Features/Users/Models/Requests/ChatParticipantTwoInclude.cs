namespace InstaConnect.Chats.Domain.Features.Users.Models.Requests;

public record ChatParticipantTwoInclude(ICollection<ChatsIncludeDescriptor> Descriptors)
	: Include<ChatsDestinationType, ChatsIncludeType, ChatsIncludeDescriptor>(Descriptors);
