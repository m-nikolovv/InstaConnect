namespace InstaConnect.Posts.Events.Features.PostCommentLikes;

public record PostCommentLikeAddedEventRequest(PostCommentLikeEventRequest PostCommentLike)
	: IEventRequest;
