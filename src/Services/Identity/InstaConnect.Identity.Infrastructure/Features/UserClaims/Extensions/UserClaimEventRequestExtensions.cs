using InstaConnect.Common.Infrastructure.Features.Events.Utilities;
using InstaConnect.Identity.Events.Features.UserClaims;

namespace InstaConnect.Identity.Infrastructure.Features.UserClaims.Extensions;

public static class UserClaimEventRequestExtensions
{
	extension(UserClaimEventRequest userClaim)
	{
		public string GetKey()
		{
			return CommonEventKeySelectorMessages.GetKey(userClaim.Id, userClaim.Claim);
		}
	}
}
