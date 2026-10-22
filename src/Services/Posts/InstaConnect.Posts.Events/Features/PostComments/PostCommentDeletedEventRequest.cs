namespace InstaConnect.Posts.Events.Features.PostComments;

public record PostCommentDeletedEventRequest(PostCommentEventRequest PostComment)
	: IEventRequest
{
	public string Key => CommonEventKeyUtilities.GetKey(PostComment.CommentId);
}
