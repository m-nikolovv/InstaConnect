namespace InstaConnect.Chats.Domain.Features.Users.Models.Requests;

public record ParticipantOneInclude(ICollection<ChatsIncludeDescriptor> Descriptors)
	: Include<ChatsDestinationType, ChatsIncludeType, ChatsIncludeDescriptor>(Descriptors);
