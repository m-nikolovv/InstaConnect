using InstaConnect.Identity.Events.Features.UserClaims;
using InstaConnect.Identity.Presentation.Tests.Features.UserClaims.Utilities;

namespace InstaConnect.Identity.Presentation.Tests.Features.UserClaims.Assertions;

public static class UserClaimMatchAssertions
{
	extension(AddUserClaimApiResponse response)
	{
		public void ShouldSatisfy(
		AddUserClaimApiRequest request,
		UserClaim userClaim)
		{
			response.ShouldSatisfy(p => p.Matches(request, userClaim));
		}
	}

	extension(GetAllUserClaimsApiResponse response)
	{
		public void ShouldSatisfy(
		GetAllUserClaimsApiRequest request,
		User user,
		ICollection<UserClaim> userClaims)
		{
			response.ShouldSatisfy(p => p.Matches(request, user, userClaims));
		}

		public void ShouldSatisfy(
			GetAllUserClaimsApiRequest request,
			User user,
			ICollection<UserClaim> userClaims,
			ISortEnumTermTransformer<UserClaim> termTransformer)
		{
			response.ShouldSatisfy(p => p.Matches(request, user, userClaims, termTransformer));
		}
	}

	extension(ActionResult<AddUserClaimApiResponse> response)
	{
		public void ShouldSatisfy(
		AddUserClaimApiRequest request,
		UserClaim userClaim)
		{
			response.ShouldBeActionResultAndSatisfy(p => p.Matches(request, userClaim));
		}
	}

	extension(ActionResult<GetAllUserClaimsApiResponse> response)
	{
		public void ShouldSatisfy(
		GetAllUserClaimsApiRequest request,
		User user,
		ICollection<UserClaim> userClaims)
		{
			response.ShouldBeActionResultAndSatisfy(p => p.Matches(request, user, userClaims));
		}

		public void ShouldSatisfy(
			GetAllUserClaimsApiRequest request,
			User user,
			ICollection<UserClaim> userClaims,
			ISortEnumTermTransformer<UserClaim> termTransformer)
		{
			response.ShouldBeActionResultAndSatisfy(p => p.Matches(request, user, userClaims, termTransformer));
		}
	}

	extension(UserClaim userClaim)
	{
		public void ShouldSatisfy(AddUserClaimApiRequest request)
		{
			userClaim.ShouldSatisfy(p => p.Matches(request));
		}
	}

	extension(UserClaimAddedEventRequest r)
	{
		public void ShouldSatisfy(AddUserClaimApiRequest request, UserClaim entity)
		{
			r.ShouldSatisfy(r => r.Matches(request, entity));
		}
	}

	extension(UserClaimDeletedEventRequest r)
	{
		public void ShouldSatisfy(DeleteUserClaimApiRequest request, UserClaim entity)
		{
			r.ShouldSatisfy(r => r.Matches(request, entity));
		}
	}
}
