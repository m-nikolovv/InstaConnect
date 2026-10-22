namespace InstaConnect.Posts.Events.Features.PostComments;

public record PostCommentAddedEventRequest(PostCommentEventRequest PostComment)
	: IEventRequest
{
	public string Id => CommonEventKeyUtilities.GetKey(PostComment.CommentId);
}
