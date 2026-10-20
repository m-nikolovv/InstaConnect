namespace InstaConnect.Posts.Events.Features.PostCommentImages;

public record PostCommentImageEventRequest(
		string Id,
		string CommentId,
		string ImageId,
		string Url,
		DateTimeOffset CreatedAtUtc);
