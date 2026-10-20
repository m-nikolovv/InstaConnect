namespace InstaConnect.Posts.Presentation.Features.PostCommentImages.Models.Responses;

public record PostCommentImageApiResponse(
	string Id,
	string CommentId,
	string ImageId,
	string Url,
	DateTimeOffset CreatedAtUtc);
