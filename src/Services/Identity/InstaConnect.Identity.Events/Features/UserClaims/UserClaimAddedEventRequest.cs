namespace InstaConnect.Identity.Events.Features.UserClaims;

public record UserClaimAddedEventRequest(UserClaimEventRequest UserClaim) : IEventRequest
{
	public string Id => CommonEventKeyUtilities.GetKey(UserClaim.Id, UserClaim.Claim);
}
