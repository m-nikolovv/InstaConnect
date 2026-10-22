namespace InstaConnect.Posts.Events.Features.PostCommentLikes;

public record PostCommentLikeDeletedEventRequest(PostCommentLikeEventRequest PostCommentLike)
	: IEventRequest;
