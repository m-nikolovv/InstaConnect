namespace InstaConnect.Identity.Events.Features.EmailConfirmationTokens;

public record EmailConfirmationTokenDeletedEventRequest(EmailConfirmationTokenEventRequest EmailConfirmationToken) : IEventRequest
{
	public string Key => CommonEventKeyUtilities.GetKey(EmailConfirmationToken.Value);
}
