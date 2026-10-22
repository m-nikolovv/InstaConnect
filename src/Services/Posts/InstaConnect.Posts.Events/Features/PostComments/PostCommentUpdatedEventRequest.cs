namespace InstaConnect.Posts.Events.Features.PostComments;

public record PostCommentUpdatedEventRequest(PostCommentEventRequest PostComment)
	: IEventRequest
{
	public string Key => CommonEventKeyUtilities.GetKey(PostComment.CommentId);
}
