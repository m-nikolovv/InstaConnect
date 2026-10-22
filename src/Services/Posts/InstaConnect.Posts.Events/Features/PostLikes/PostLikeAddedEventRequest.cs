namespace InstaConnect.Posts.Events.Features.PostLikes;

public record PostLikeAddedEventRequest(PostLikeEventRequest PostLike)
	: IEventRequest
{
	public string Id => CommonEventKeyUtilities.GetKey(PostLike.Id, PostLike.UserId);
}
