using InstaConnect.Posts.Events.Features.Posts;

namespace InstaConnect.Posts.Events.Features.PostLikes;

public record PostLikeEventRequest(
		string Id,
		string UserId,
		UserEventRequest User,
		PostEventRequest Post,
		DateTimeOffset CreatedAtUtc)
	: IEventRequest;
