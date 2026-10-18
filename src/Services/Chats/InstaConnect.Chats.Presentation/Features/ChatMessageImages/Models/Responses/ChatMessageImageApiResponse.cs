namespace InstaConnect.Chats.Presentation.Features.ChatMessageImages.Models.Responses;

public record ChatMessageImageApiResponse(
	string ParticipantOneId,
	string ParticipantTwoId,
	string MessageId,
	string ImageId,
	string Url,
	DateTimeOffset CreatedAtUtc);
