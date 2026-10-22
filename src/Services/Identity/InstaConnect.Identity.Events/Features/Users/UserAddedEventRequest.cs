namespace InstaConnect.Identity.Events.Features.Users;

public record UserAddedEventRequest(UserEventRequest User) : IEventRequest
{
	public string Key => CommonEventKeyUtilities.GetKey(User.Id);
}
