namespace InstaConnect.Chats.Domain.Features.ChatMessageImages.Models.Responses;

public record ChatMessageImageResponse(
	ChatMessageImageId Id,
	Url Url,
	DateTimeOffset CreatedAtUtc) : IEntityResponse;
