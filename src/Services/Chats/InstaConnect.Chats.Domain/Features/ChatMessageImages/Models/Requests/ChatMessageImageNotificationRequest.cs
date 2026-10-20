namespace InstaConnect.Chats.Domain.Features.ChatMessageImages.Models.Requests;

public record ChatMessageImageNotificationRequest(
	string ParticipantOneId,
	string ParticipantTwoId,
	string MessageId,
	string ImageId,
	string Url,
	DateTimeOffset CreatedAtUtc);
