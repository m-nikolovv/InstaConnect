namespace InstaConnect.Posts.Events.Features.Posts;

public record PostAddedEventRequest(PostEventRequest Post) : IEventRequest
{
	public string Id => CommonEventKeyUtilities.GetKey(Post.Id);
}
