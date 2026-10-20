namespace InstaConnect.Posts.Application.Features.PostCommentImages.Models;

public record PostCommentImageQueryResponse(
	string Id,
	string CommentId,
	string ImageId,
	string Url,
	DateTimeOffset CreatedAtUtc);
