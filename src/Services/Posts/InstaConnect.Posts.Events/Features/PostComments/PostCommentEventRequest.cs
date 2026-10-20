using InstaConnect.Posts.Events.Features.PostCommentImages;
using InstaConnect.Posts.Events.Features.Posts;

namespace InstaConnect.Posts.Events.Features.PostComments;

public record PostCommentEventRequest(
		string Id,
		string CommentId,
		string UserId,
		string Content,
		string Summary,
		UserEventRequest User,
		PostEventRequest Post,
		ICollection<PostCommentImageEventRequest> PostCommentImages,
		DateTimeOffset CreatedAtUtc,
		DateTimeOffset UpdatedAtUtc);
