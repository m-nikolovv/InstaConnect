namespace InstaConnect.Posts.Events.Features.PostLikes;

public record PostLikeAddedEventRequest(PostLikeEventRequest PostLike)
	: IEventRequest
{
	public string Key => CommonEventKeyUtilities.GetKey(PostLike.Id, PostLike.UserId);
}
