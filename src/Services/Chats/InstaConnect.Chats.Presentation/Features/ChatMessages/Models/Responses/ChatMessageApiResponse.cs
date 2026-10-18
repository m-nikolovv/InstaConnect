namespace InstaConnect.Chats.Presentation.Features.ChatMessages.Models.Responses;

public record ChatMessageApiResponse(
	string ParticipantOneId,
	string ParticipantTwoId,
	string MessageId,
	string SenderId,
	string Content,
	string Summary,
	ChatApiResponse? Chat,
	UserApiResponse? Sender,
	ICollection<ChatMessageImageApiResponse> ChatMessageImages,
	DateTimeOffset CreatedAtUtc,
	DateTimeOffset UpdatedAtUtc);
