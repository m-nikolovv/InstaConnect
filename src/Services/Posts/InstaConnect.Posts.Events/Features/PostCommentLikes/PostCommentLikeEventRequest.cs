using InstaConnect.Posts.Events.Features.PostComments;

namespace InstaConnect.Posts.Events.Features.PostCommentLikes;

public record PostCommentLikeEventRequest(
	string Id,
	string CommentId,
	string UserId,
	UserEventRequest User,
	PostCommentEventRequest PostComment,
	DateTimeOffset CreatedAtUtc);
