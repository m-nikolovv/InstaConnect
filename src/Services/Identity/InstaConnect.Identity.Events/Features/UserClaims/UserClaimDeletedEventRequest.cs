namespace InstaConnect.Identity.Events.Features.UserClaims;

public record UserClaimDeletedEventRequest(UserClaimEventRequest UserClaim) : IEventRequest
{
	public string Key => CommonEventKeyUtilities.GetKey(UserClaim.Id, UserClaim.Claim);
}
