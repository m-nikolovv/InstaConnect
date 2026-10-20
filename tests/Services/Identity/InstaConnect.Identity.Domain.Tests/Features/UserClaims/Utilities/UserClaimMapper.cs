using InstaConnect.Identity.Domain.Features.UserClaims.Models.Responses;

namespace InstaConnect.Identity.Domain.Tests.Features.UserClaims.Utilities;

public static class UserClaimMapper
{
	extension(User user)
	{
		public UserResponse ToResponse(
			GetAllUserClaimsQuery query)
		{
			return user.ToFullResponse();
		}
	}

	extension(UserClaim userClaim)
	{
		internal UserClaimResponse ToFullResponse()
		{
			return new(userClaim.Id,
					   userClaim.User?.ToFullResponse(),
					   userClaim.CreatedAtUtc);
		}

		internal UserClaimResponse ToResponseWithoutUser()
		{
			return new(userClaim.Id,
					   null,
					   userClaim.CreatedAtUtc);
		}

		public UserClaim To(AddUserClaimCommand command)
		{
			return new(
				new(command.Id, command.Claim),
				userClaim.CreatedAtUtc);
		}

		public UserClaimId ToResponse(
			AddUserClaimCommand command)
		{
			return userClaim.ToId();
		}
	}

	extension(ICollection<UserClaim> userClaims)
	{
		public ICollection<UserClaimResponse> ToResponse(
			GetAllUserClaimsQuery query)
		{
			return userClaims.Filter(query.Pagination, userClaim => userClaim.MatchesFilter(query.Filter), userClaim => userClaim.ToResponseWithoutUser());
		}

		public long ToTotalCountResponse(
			GetAllUserClaimsQuery query)
		{
			return userClaims.Count(userClaim => userClaim.MatchesFilter(query.Filter));
		}
	}
}
