namespace InstaConnect.Posts.Domain.Features.PostCommentImages.Models.Responses;

public record PostCommentImageResponse(
	PostCommentImageId Id,
	Url Url,
	DateTimeOffset CreatedAtUtc) : IEntityResponse;
