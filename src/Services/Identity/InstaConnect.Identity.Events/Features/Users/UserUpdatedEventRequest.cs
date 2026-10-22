namespace InstaConnect.Identity.Events.Features.Users;

public record UserUpdatedEventRequest(UserEventRequest User) : IEventRequest
{
	public string Id => CommonEventKeyUtilities.GetKey(User.Id);
}
