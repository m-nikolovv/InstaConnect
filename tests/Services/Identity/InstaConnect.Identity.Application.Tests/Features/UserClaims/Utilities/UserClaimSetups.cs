using InstaConnect.Identity.Application.Features.UserClaims.Models;
using InstaConnect.Identity.Domain.Features.UserClaims.Models.Responses;
using InstaConnect.Identity.Domain.Features.UserClaims.Models.ValueObjects;

namespace InstaConnect.Identity.Application.Tests.Features.UserClaims.Utilities;

public static class UserClaimSetups
{
	extension(IServiceScope serviceScope)
	{
		internal async Task<UserClaim?> GetByIdAsync(
		UserClaimIdCommandResponse id,
		CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				new UserClaimId(new(id.Id), id.Claim),
				cancellationToken);
		}

		public async Task<UserClaim?> GetByIdAsync(
		AddUserClaimCommandResponse response,
		CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				response.Response,
				cancellationToken);
		}

		public async Task<UserClaimResponse?> GetUserClaimCacheByIdAsync(
			DeleteUserClaimCommandRequest request,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetUserClaimCacheByIdAsync(request.Id, request.Claim, request.Id, cancellationToken);
		}

		public async Task InitializeAddAsync(
			AddUserClaimCommandRequest request,
			UserClaim userClaim,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeAddAsync(userClaim, cancellationToken);
		}

		public async Task DisposeAddAsync(
			AddUserClaimCommandRequest request,
			UserClaim userClaim,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeAddAsync(userClaim, cancellationToken);
		}

		public async Task InitializeDeleteAsync(
			DeleteUserClaimCommandRequest request,
			UserClaim userClaim,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeDeleteAsync(userClaim, request.Id, cancellationToken);
		}

		public async Task DisposeDeleteAsync(
			DeleteUserClaimCommandRequest request,
			UserClaim userClaim,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeDeleteAsync(userClaim, cancellationToken);
		}

		public async Task AddUserClaimCacheAsync(
			DeleteUserClaimCommandRequest request,
			UserClaim userClaim,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddUserClaimCacheAsync(userClaim, request.Id, cancellationToken);
		}

		public async Task InitializeGetAllAsync(
			GetAllUserClaimsQueryRequest request,
			ICollection<UserClaim> userClaims,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeGetAllAsync(userClaims, cancellationToken);
		}

		public async Task DisposeGetAllAsync(
			GetAllUserClaimsQueryRequest request,
			ICollection<UserClaim> userClaims,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeGetAllAsync(userClaims, cancellationToken);
		}
	}
}
