namespace InstaConnect.Identity.Events.Features.Users;

public sealed record UserDeletedEventRequest(UserEventRequest User) : IEventRequest
{
	public string Id => CommonEventKeyUtilities.GetKey(User.Id);
}
