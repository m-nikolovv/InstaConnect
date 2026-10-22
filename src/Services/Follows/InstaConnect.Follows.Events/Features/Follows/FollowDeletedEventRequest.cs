namespace InstaConnect.Follows.Events.Features.Follows;

public record FollowDeletedEventRequest(FollowEventRequest Follow) : IEventRequest
{
	public string Key => CommonEventKeyUtilities.GetKey(Follow.FollowerId, Follow.FollowingId);
}
