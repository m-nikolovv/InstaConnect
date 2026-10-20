namespace InstaConnect.Chats.Domain.Features.Users.Models.Requests;

public record ParticipantTwoInclude(ICollection<ChatsIncludeDescriptor> Descriptors)
	: Include<ChatsDestinationType, ChatsIncludeType, ChatsIncludeDescriptor>(Descriptors);
