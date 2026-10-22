namespace InstaConnect.Follows.Events.Features.Follows;

public record FollowDeletedEventRequest(FollowEventRequest Follow) : IEventRequest
{
	public string Id => CommonEventKeyUtilities.GetKey(Follow.FollowerId, Follow.FollowingId);
}
