namespace InstaConnect.Chats.Application.Features.ChatMessages.Models;

public record ChatMessageQueryResponse(
	string ParticipantOneId,
	string ParticipantTwoId,
	string MessageId,
	string SenderId,
	string Content,
	string Summary,
	ChatQueryResponse? Chat,
	UserQueryResponse? Sender,
	ICollection<ChatMessageImageQueryResponse> ChatMessageImages,
	DateTimeOffset CreatedAtUtc,
	DateTimeOffset UpdatedAtUtc);
