namespace InstaConnect.Posts.Events.Features.PostCommentLikes;

public record PostCommentLikeAddedEventRequest(PostCommentLikeEventRequest PostCommentLike)
	: IEventRequest
{
	public string Key => CommonEventKeyUtilities.GetKey(PostCommentLike.CommentId, PostCommentLike.UserId);
}
