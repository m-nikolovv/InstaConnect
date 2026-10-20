using InstaConnect.Chats.Domain.Features.ChatMessageImages.Models.Responses;

namespace InstaConnect.Chats.Domain.Features.ChatMessages.Models.Responses;

public record ChatMessageResponse(
	ChatMessageId Id,
	string Content,
	Summary Summary,
	UserId SenderId,
	ChatResponse? Chat,
	UserResponse? Sender,
	ICollection<ChatMessageImageResponse> ChatMessageImages,
	DateTimeOffset CreatedAtUtc,
	DateTimeOffset UpdatedAtUtc) : IEntityResponse;
