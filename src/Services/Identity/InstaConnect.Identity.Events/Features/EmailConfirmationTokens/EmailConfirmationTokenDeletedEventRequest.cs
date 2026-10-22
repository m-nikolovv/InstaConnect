namespace InstaConnect.Identity.Events.Features.EmailConfirmationTokens;

public record EmailConfirmationTokenDeletedEventRequest(EmailConfirmationTokenEventRequest EmailConfirmationToken) : IEventRequest
{
	public string Id => CommonEventKeyUtilities.GetKey(EmailConfirmationToken.Value);
}
