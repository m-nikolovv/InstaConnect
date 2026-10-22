namespace InstaConnect.Identity.Events.Features.UserClaims;

public record UserClaimDeletedEventRequest(UserClaimEventRequest UserClaim) : IEventRequest
{
	public string Id => CommonEventKeyUtilities.GetKey(UserClaim.Id, UserClaim.Claim);
}
