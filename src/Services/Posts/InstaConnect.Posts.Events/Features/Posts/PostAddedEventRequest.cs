namespace InstaConnect.Posts.Events.Features.Posts;

public record PostAddedEventRequest(PostEventRequest Post) : IEventRequest
{
	public string Key => CommonEventKeyUtilities.GetKey(Post.Id);
}
