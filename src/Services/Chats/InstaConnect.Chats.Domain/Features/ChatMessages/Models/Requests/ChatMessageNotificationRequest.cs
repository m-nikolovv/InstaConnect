namespace InstaConnect.Chats.Domain.Features.ChatMessages.Models.Requests;

public record ChatMessageNotificationRequest(
	string ParticipantOneId,
	string ParticipantTwoId,
	string MessageId,
	UserNotificationRequest Sender,
	ChatNotificationRequest Chat,
	ICollection<ChatMessageImageNotificationRequest> ChatMessageImages,
	string Content,
	string Summary,
	DateTimeOffset CreatedAtUtc,
	DateTimeOffset UpdatedAtUtc);
