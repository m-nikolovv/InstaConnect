namespace InstaConnect.Identity.Events.Features.Users;

public record UserAddedEventRequest(UserEventRequest User) : IEventRequest
{
	public string Id => CommonEventKeyUtilities.GetKey(User.Id);
}
