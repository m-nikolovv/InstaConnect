namespace InstaConnect.Posts.Events.Features.PostComments;

public record PostCommentDeletedEventRequest(PostCommentEventRequest PostComment)
	: IEventRequest
{
	public string Id => CommonEventKeyUtilities.GetKey(PostComment.CommentId);
}
