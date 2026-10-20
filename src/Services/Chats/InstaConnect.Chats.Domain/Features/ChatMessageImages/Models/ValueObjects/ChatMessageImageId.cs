namespace InstaConnect.Chats.Domain.Features.ChatMessageImages.Models.ValueObjects;

public record ChatMessageImageId(ChatMessageId Id, string ImageId) : IEntityId;
