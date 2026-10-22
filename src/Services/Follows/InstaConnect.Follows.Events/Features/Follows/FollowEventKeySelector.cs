namespace InstaConnect.Follows.Events.Features.Follows;

internal class FollowEventKeySelector :
	IEventKeySelector<FollowAddedEventRequest>,
	IEventKeySelector<FollowDeletedEventRequest>
{
	public string GetKey(FollowAddedEventRequest eventRequest)
	{
		return GetKey(eventRequest.Follow);
	}

	public string GetKey(FollowDeletedEventRequest eventRequest)
	{
		return GetKey(eventRequest.Follow);
	}

	public string GetKey(FollowEventRequest follow)
	{
		return string.Join(':', follow.FollowerId, follow.FollowingId);
	}
}
