namespace InstaConnect.Identity.Events.Features.ForgotPasswordTokens;

public record ForgotPasswordTokenDeletedEventRequest(ForgotPasswordTokenEventRequest ForgotPasswordToken) : IEventRequest
{
	public string Key => CommonEventKeyUtilities.GetKey(ForgotPasswordToken.Value);
}
