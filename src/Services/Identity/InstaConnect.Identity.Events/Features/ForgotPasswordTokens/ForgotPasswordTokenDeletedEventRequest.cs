namespace InstaConnect.Identity.Events.Features.ForgotPasswordTokens;

public record ForgotPasswordTokenDeletedEventRequest(ForgotPasswordTokenEventRequest ForgotPasswordToken) : IEventRequest
{
	public string Id => CommonEventKeyUtilities.GetKey(ForgotPasswordToken.Value);
}
