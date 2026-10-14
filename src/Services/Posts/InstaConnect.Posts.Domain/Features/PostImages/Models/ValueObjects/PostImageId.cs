namespace InstaConnect.Posts.Domain.Features.PostImages.Models.ValueObjects;

public record PostImageId(PostId Id, string ImageId) : IEntityId;
