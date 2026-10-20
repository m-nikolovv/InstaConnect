namespace InstaConnect.Posts.Domain.Features.PostCommentImages.Models.ValueObjects;

public record PostCommentImageId(PostCommentId Id, string ImageId) : IEntityId;
