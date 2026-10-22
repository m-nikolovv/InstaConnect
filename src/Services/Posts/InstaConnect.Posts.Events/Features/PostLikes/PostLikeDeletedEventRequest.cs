namespace InstaConnect.Posts.Events.Features.PostLikes;

public record PostLikeDeletedEventRequest(PostLikeEventRequest PostLike)
	: IEventRequest
{
	public string Id => CommonEventKeyUtilities.GetKey(PostLike.Id, PostLike.UserId);
}
