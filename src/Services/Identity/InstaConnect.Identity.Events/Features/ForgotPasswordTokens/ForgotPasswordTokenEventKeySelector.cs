namespace InstaConnect.Identity.Events.Features.ForgotPasswordTokens;

internal class ForgotPasswordTokenEventKeySelector :
	IEventKeySelector<ForgotPasswordTokenAddedEventRequest>,
	IEventKeySelector<ForgotPasswordTokenDeletedEventRequest>
{
	public string GetKey(ForgotPasswordTokenAddedEventRequest eventRequest)
	{
		return GetKey(eventRequest.ForgotPasswordToken);
	}

	public string GetKey(ForgotPasswordTokenDeletedEventRequest eventRequest)
	{
		return GetKey(eventRequest.ForgotPasswordToken);
	}

	public string GetKey(ForgotPasswordTokenEventRequest forgotPasswordToken)
	{
		return forgotPasswordToken.Value;
	}
}
