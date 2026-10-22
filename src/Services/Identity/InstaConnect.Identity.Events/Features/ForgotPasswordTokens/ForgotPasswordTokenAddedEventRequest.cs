namespace InstaConnect.Identity.Events.Features.ForgotPasswordTokens;

public record ForgotPasswordTokenAddedEventRequest(ForgotPasswordTokenEventRequest ForgotPasswordToken) : IEventRequest
{
	public string Key => CommonEventKeyUtilities.GetKey(ForgotPasswordToken.Value);
}
