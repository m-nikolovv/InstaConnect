namespace InstaConnect.Posts.Events.Features.PostCommentLikes;

public record PostCommentLikeAddedEventRequest(PostCommentLikeEventRequest PostCommentLike)
	: IEventRequest
{
	public string Id => CommonEventKeyUtilities.GetKey(PostCommentLike.CommentId, PostCommentLike.UserId);
}
