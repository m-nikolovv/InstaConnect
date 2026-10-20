namespace InstaConnect.Chats.Application.Features.ChatMessageImages.Models;

public record ChatMessageImageQueryResponse(
	string ParticipantOneId,
	string ParticipantTwoId,
	string MessageId,
	string ImageId,
	string Url,
	DateTimeOffset CreatedAtUtc);
