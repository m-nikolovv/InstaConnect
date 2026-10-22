namespace InstaConnect.Posts.Events.Features.PostCommentLikes;

internal class PostCommentLikeEventKeySelector :
	IEventKeySelector<PostCommentLikeAddedEventRequest>,
	IEventKeySelector<PostCommentLikeDeletedEventRequest>
{
	public string GetKey(PostCommentLikeAddedEventRequest eventRequest)
	{
		return GetKey(eventRequest.PostCommentLike);
	}

	public string GetKey(PostCommentLikeDeletedEventRequest eventRequest)
	{
		return GetKey(eventRequest.PostCommentLike);
	}

	public string GetKey(PostCommentLikeEventRequest postCommentLike)
	{
		return string.Join(':', postCommentLike.CommentId, postCommentLike.UserId);
	}
}
