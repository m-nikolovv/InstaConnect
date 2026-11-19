using InstaConnect.Identity.Application.Tests.Features.UserClaims.Utilities;
using InstaConnect.Identity.Domain.Features.UserClaims.Abstractions;

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

		public async Task ShouldHaveReceivedOneGetAllAsync(
			GetAllUserClaimsQuery query,
			CancellationToken cancellationToken)
		{
			await userClaimService.ShouldHaveReceivedOne().GetAllAsync(query, cancellationToken);
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

		public async Task ShouldHaveReceivedOneAddAsync(
			AddUserClaimCommand command,
			CancellationToken cancellationToken)
		{
			await userClaimService.ShouldHaveReceivedOne().AddAsync(command, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteAsync(
			DeleteUserClaimCommandRequest request,
			CancellationToken cancellationToken)
		{
			await userClaimService.ShouldHaveReceivedOneDeleteAsync(request.IsDeleteUserClaimCommand(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteAsync(
			DeleteUserClaimCommand command,
			CancellationToken cancellationToken)
		{
			await userClaimService.ShouldHaveReceivedOne().DeleteAsync(command, cancellationToken);
		}
	}
}
