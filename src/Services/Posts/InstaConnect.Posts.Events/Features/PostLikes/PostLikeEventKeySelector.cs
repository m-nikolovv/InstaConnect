namespace InstaConnect.Posts.Events.Features.PostLikes;

internal class PostLikeEventKeySelector :
	IEventKeySelector<PostLikeAddedEventRequest>,
	IEventKeySelector<PostLikeDeletedEventRequest>
{
	public string GetKey(PostLikeAddedEventRequest eventRequest)
	{
		return GetKey(eventRequest.PostLike);
	}

	public string GetKey(PostLikeDeletedEventRequest eventRequest)
	{
		return GetKey(eventRequest.PostLike);
	}

	public string GetKey(PostLikeEventRequest postLike)
	{
		return string.Join(':', postLike.Id, postLike.UserId);
	}
}
