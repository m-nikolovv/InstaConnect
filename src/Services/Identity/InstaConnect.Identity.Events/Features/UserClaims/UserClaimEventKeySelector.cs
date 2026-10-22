namespace InstaConnect.Identity.Events.Features.UserClaims;

internal class UserClaimEventKeySelector :
	IEventKeySelector<UserClaimAddedEventRequest>,
	IEventKeySelector<UserClaimDeletedEventRequest>
{
	public string GetKey(UserClaimAddedEventRequest eventRequest)
	{
		return GetKey(eventRequest.UserClaim);
	}

	public string GetKey(UserClaimDeletedEventRequest eventRequest)
	{
		return GetKey(eventRequest.UserClaim);
	}

	public string GetKey(UserClaimEventRequest userClaim)
	{
		return string.Join(':', userClaim.Id, userClaim.Claim);
	}
}
