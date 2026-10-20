using InstaConnect.Common.Application.Tests.Features.Utilities;

namespace InstaConnect.Identity.Presentation.Tests.Features.UserClaims.Utilities;

public static class UserClaimMockSetups
{
	extension(IApplicationSender sender)
	{
		public void SetupSendAsync(
		GetAllUserClaimsApiRequest request,
		User user,
		ICollection<UserClaim> userClaims,
		CancellationToken cancellationToken)
		{
			sender.SetupSendAsync(request.IsGetAllUserClaimsQueryRequest(), userClaims.ToResponse(request, user), cancellationToken);
		}

		public void SetupSendAsync(
			AddUserClaimApiRequest request,
			UserClaim userClaim,
			CancellationToken cancellationToken)
		{
			sender.SetupSendAsync(request.IsAddUserClaimCommandRequest(), userClaim.ToResponse(request), cancellationToken);
		}
	}
}
