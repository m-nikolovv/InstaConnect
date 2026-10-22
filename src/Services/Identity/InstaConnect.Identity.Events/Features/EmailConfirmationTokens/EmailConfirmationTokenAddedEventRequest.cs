namespace InstaConnect.Identity.Events.Features.EmailConfirmationTokens;

public record EmailConfirmationTokenAddedEventRequest(EmailConfirmationTokenEventRequest EmailConfirmationToken) : IEventRequest
{
	public string Id => CommonEventKeyUtilities.GetKey(EmailConfirmationToken.Value);
}
