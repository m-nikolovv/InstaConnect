namespace InstaConnect.Identity.Events.Features.UserClaims;

public record UserClaimAddedEventRequest(UserClaimEventRequest UserClaim) : IEventRequest
{
	public string Key => CommonEventKeyUtilities.GetKey(UserClaim.Id, UserClaim.Claim);
}
