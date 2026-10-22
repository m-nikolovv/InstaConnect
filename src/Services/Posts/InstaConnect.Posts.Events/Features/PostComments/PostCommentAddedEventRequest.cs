namespace InstaConnect.Posts.Events.Features.PostComments;

public record PostCommentAddedEventRequest(PostCommentEventRequest PostComment)
	: IEventRequest
{
	public string Key => CommonEventKeyUtilities.GetKey(PostComment.CommentId);
}
