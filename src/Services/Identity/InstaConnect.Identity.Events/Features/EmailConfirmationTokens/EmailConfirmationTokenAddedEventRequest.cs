namespace InstaConnect.Identity.Events.Features.EmailConfirmationTokens;

public record EmailConfirmationTokenAddedEventRequest(EmailConfirmationTokenEventRequest EmailConfirmationToken) : IEventRequest
{
	public string Key => CommonEventKeyUtilities.GetKey(EmailConfirmationToken.Value);
}
