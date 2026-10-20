namespace InstaConnect.Chats.Domain.Features.Common.Models.Requests;

public record ChatsIncludeDescriptor(
	ChatsDestinationType DestinationType,
	ChatsIncludeType IncludeType)
	: IIncludeDescriptor<ChatsDestinationType, ChatsIncludeType>;
