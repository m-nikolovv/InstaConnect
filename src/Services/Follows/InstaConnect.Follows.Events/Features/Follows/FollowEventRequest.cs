namespace InstaConnect.Follows.Events.Features.Follows;

public record FollowEventRequest(
		string FollowerId,
		string FollowingId,
		UserEventRequest Follower,
		UserEventRequest Following,
		DateTimeOffset CreatedAtUtc);
