namespace InstaConnect.Posts.Events.Features.Posts;

internal class PostEventKeySelector :
	IEventKeySelector<PostAddedEventRequest>,
	IEventKeySelector<PostUpdatedEventRequest>,
	IEventKeySelector<PostDeletedEventRequest>
{
	public string GetKey(PostAddedEventRequest eventRequest)
	{
		return GetKey(eventRequest.Post);
	}

	public string GetKey(PostUpdatedEventRequest eventRequest)
	{
		return GetKey(eventRequest.Post);
	}

	public string GetKey(PostDeletedEventRequest eventRequest)
	{
		return GetKey(eventRequest.Post);
	}

	public string GetKey(PostEventRequest post)
	{
		return post.Id;
	}
}
