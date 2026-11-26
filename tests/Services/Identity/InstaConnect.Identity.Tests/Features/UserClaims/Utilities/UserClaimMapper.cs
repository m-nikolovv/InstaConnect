using InstaConnect.Identity.Domain.Features.UserClaims.Models.Responses;

namespace InstaConnect.Identity.Tests.Features.UserClaims.Utilities;

public static class UserClaimMapper
{
	extension(UserClaim userClaim)
	{
		public UserClaimId ToId(
)
		{
			return userClaim.Id;
		}

		public UserClaimResponse ToFullResponse()
		{
			return new(userClaim.Id,
					   userClaim.User?.ToFullResponse(),
					   userClaim.CreatedAtUtc);
		}

		public UserClaimResponse ToResponseWithoutUser()
		{
			return new(userClaim.Id,
					   null,
					   userClaim.CreatedAtUtc);
		}
	}

	extension(ICollection<UserClaim> userClaims)
	{
		public ICollection<UserClaimResponse> ToFullResponse()
		{
			return [.. userClaims.Select(userClaim => userClaim.ToFullResponse())];
		}
	}
}
