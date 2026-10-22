namespace InstaConnect.Posts.Events.Features.PostComments;

internal class PostCommentEventKeySelector :
	IEventKeySelector<PostCommentAddedEventRequest>,
	IEventKeySelector<PostCommentUpdatedEventRequest>,
	IEventKeySelector<PostCommentDeletedEventRequest>
{
	public string GetKey(PostCommentAddedEventRequest eventRequest)
	{
		return GetKey(eventRequest.PostComment);
	}

	public string GetKey(PostCommentUpdatedEventRequest eventRequest)
	{
		return GetKey(eventRequest.PostComment);
	}

	public string GetKey(PostCommentDeletedEventRequest eventRequest)
	{
		return GetKey(eventRequest.PostComment);
	}

	public string GetKey(PostCommentEventRequest postComment)
	{
		return postComment.CommentId;
	}
}
