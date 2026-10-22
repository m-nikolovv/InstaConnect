namespace InstaConnect.Identity.Events.Features.Users;

public sealed record UserDeletedEventRequest(UserEventRequest User) : IEventRequest
{
	public string Key => CommonEventKeyUtilities.GetKey(User.Id);
}
