namespace InstaConnect.Posts.Events.Features.PostLikes;

public record PostLikeAddedEventRequest(PostLikeEventRequest PostLike)
	: IEventRequest;
