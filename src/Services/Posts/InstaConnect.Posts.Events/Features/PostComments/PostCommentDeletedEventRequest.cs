namespace InstaConnect.Posts.Events.Features.PostComments;

public record PostCommentDeletedEventRequest(PostCommentEventRequest PostComment)
	: IEventRequest;
