namespace InstaConnect.Identity.Events.Features.ForgotPasswordTokens;

public record ForgotPasswordTokenAddedEventRequest(ForgotPasswordTokenEventRequest ForgotPasswordToken) : IEventRequest
{
	public string Id => CommonEventKeyUtilities.GetKey(ForgotPasswordToken.Value);
}
