namespace InstaConnect.Identity.Events.Features.Users;

public record UserUpdatedEventRequest(UserEventRequest User) : IEventRequest
{
	public string Key => CommonEventKeyUtilities.GetKey(User.Id);
}
