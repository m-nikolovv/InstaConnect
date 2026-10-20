using InstaConnect.Identity.Domain.Features.UserClaims.Abstractions;
using InstaConnect.Identity.Domain.Tests.Features.UserClaims.Utilities;

namespace InstaConnect.Identity.Application.Tests.Features.UserClaims.Utilities;

public static class UserClaimMockSetups
{
	extension(IUserClaimQueryService service)
	{
		public void SetupGetAllAsync(
		GetAllUserClaimsQueryRequest request,
		User user,
		ICollection<UserClaim> userClaims,
		CancellationToken cancellationToken)
		{
			service.SetupGetAllAsync(request.IsGetAllUserClaimsQuery(), userClaims.ToResponse(request, user), cancellationToken);
		}
	}

	extension(IUserClaimCommandService service)
	{
		public void SetupAddAsync(
		AddUserClaimCommandRequest request,
		UserClaim userClaim,
		CancellationToken cancellationToken)
		{
			service.SetupAddAsync(request.IsAddUserClaimCommand(), userClaim.ToResponse(request), cancellationToken);
		}
	}
}
