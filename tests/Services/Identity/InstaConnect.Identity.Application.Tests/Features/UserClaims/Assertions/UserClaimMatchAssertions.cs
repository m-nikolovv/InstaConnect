using InstaConnect.Identity.Application.Tests.Features.UserClaims.Utilities;
using InstaConnect.Identity.Events.Features.UserClaims;

namespace InstaConnect.Identity.Application.Tests.Features.UserClaims.Assertions;

public static class UserClaimMatchAssertions
{
	extension(AddUserClaimCommandResponse response)
	{
		public void ShouldSatisfy(AddUserClaimCommandRequest request, UserClaim userClaim)
		{
			response.ShouldSatisfy(p => p.Matches(request, userClaim));
		}
	}

	extension(GetAllUserClaimsQueryResponse response)
	{
		public void ShouldSatisfy(
			GetAllUserClaimsQueryRequest request,
			User user,
			ICollection<UserClaim> userClaims)
		{
			response.ShouldSatisfy(p => p.Matches(request, user, userClaims));
		}

		public void ShouldSatisfy(
			GetAllUserClaimsQueryRequest request,
			User user,
			ICollection<UserClaim> userClaims,
			ISortEnumTermTransformer<UserClaim> termTransformer)
		{
			response.ShouldSatisfy(p => p.Matches(request, user, userClaims, termTransformer));
		}
	}

	extension(UserClaim userClaim)
	{
		public void ShouldSatisfy(AddUserClaimCommandRequest request)
		{
			userClaim.ShouldSatisfy(p => p.Matches(request));
		}
	}

	extension(UserClaimAddedEventRequest r)
	{
		public void ShouldSatisfy(AddUserClaimCommandRequest request, UserClaim entity)
		{
			r.ShouldSatisfy(r => r.Matches(request, entity));
		}
	}

	extension(UserClaimDeletedEventRequest r)
	{
		public void ShouldSatisfy(DeleteUserClaimCommandRequest request, UserClaim entity)
		{
			r.ShouldSatisfy(r => r.Matches(request, entity));
		}
	}
}
