namespace InstaConnect.Identity.Events.Features.Users;

internal class UserEventKeySelector :
	IEventKeySelector<UserAddedEventRequest>,
	IEventKeySelector<UserUpdatedEventRequest>,
	IEventKeySelector<UserDeletedEventRequest>
{
	public string GetKey(UserAddedEventRequest eventRequest)
	{
		return GetKey(eventRequest.User);
	}

	public string GetKey(UserUpdatedEventRequest eventRequest)
	{
		return GetKey(eventRequest.User);
	}

	public string GetKey(UserDeletedEventRequest eventRequest)
	{
		return GetKey(eventRequest.User);
	}

	public string GetKey(UserEventRequest user)
	{
		return user.Id;
	}
}
