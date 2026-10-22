namespace InstaConnect.Follows.Events.Features.Follows;

public record FollowAddedEventRequest(FollowEventRequest Follow) : IEventRequest
{
	public string Key => CommonEventKeyUtilities.GetKey(Follow.FollowerId, Follow.FollowingId);
}
