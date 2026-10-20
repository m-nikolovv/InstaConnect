using InstaConnect.Identity.Application.Tests.Features.UserClaims.Utilities;
using InstaConnect.Identity.Domain.Features.UserClaims.Abstractions;
using InstaConnect.Identity.Domain.Tests.Features.UserClaims.Assertions;

namespace InstaConnect.Identity.Application.Tests.Features.UserClaims.Assertions;

public static class UserClaimMockAssertions
{
	extension(IUserClaimQueryService userClaimService)
	{
		public async Task ShouldHaveReceivedOneGetAllAsync(
		GetAllUserClaimsQueryRequest request,
		CancellationToken cancellationToken)
		{
			await userClaimService.ShouldHaveReceivedOneGetAllAsync(request.IsGetAllUserClaimsQuery(), cancellationToken);
		}
	}

	extension(IUserClaimCommandService userClaimService)
	{
		public async Task ShouldHaveReceivedOneAddAsync(
		AddUserClaimCommandRequest request,
		CancellationToken cancellationToken)
		{
			await userClaimService.ShouldHaveReceivedOneAddAsync(request.IsAddUserClaimCommand(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteAsync(
			DeleteUserClaimCommandRequest request,
			CancellationToken cancellationToken)
		{
			await userClaimService.ShouldHaveReceivedOneDeleteAsync(request.IsDeleteUserClaimCommand(), cancellationToken);
		}
	}
}
