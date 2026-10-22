namespace InstaConnect.Identity.Events.Features.EmailConfirmationTokens;

internal class EmailConfirmationTokenEventKeySelector :
	IEventKeySelector<EmailConfirmationTokenAddedEventRequest>,
	IEventKeySelector<EmailConfirmationTokenDeletedEventRequest>
{
	public string GetKey(EmailConfirmationTokenAddedEventRequest eventRequest)
	{
		return GetKey(eventRequest.EmailConfirmationToken);
	}

	public string GetKey(EmailConfirmationTokenDeletedEventRequest eventRequest)
	{
		return GetKey(eventRequest.EmailConfirmationToken);
	}

	public string GetKey(EmailConfirmationTokenEventRequest emailConfirmationToken)
	{
		return emailConfirmationToken.Value;
	}
}
