using InstaConnect.Identity.Application.Features.UserClaims.Commands.Add;
using InstaConnect.Identity.Application.Features.UserClaims.Commands.Delete;
using InstaConnect.Identity.Application.Features.UserClaims.Queries.GetAll;

namespace InstaConnect.Identity.Presentation.Tests.Features.UserClaims.Utilities;

public static class UserClaimPresentationMatcher
{
	extension(GetAllUserClaimsApiRequest request)
	{
		public GetAllUserClaimsQueryRequest IsGetAllUserClaimsQueryRequest()
		{
			return Matcher.Is<GetAllUserClaimsQueryRequest>(p => p.Matches(request));
		}
	}

	extension(AddUserClaimApiRequest request)
	{
		public AddUserClaimCommandRequest IsAddUserClaimCommandRequest()
		{
			return Matcher.Is<AddUserClaimCommandRequest>(p => p.Matches(request));
		}
	}

	extension(DeleteUserClaimApiRequest request)
	{
		public DeleteUserClaimCommandRequest IsDeleteUserClaimCommandRequest()
		{
			return Matcher.Is<DeleteUserClaimCommandRequest>(p => p.Matches(request));
		}
	}
}
