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

		public async Task SetupAddAsync(
			AddUserClaimCommandRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupAddUserClaimAsync(user, cancellationToken);
		}

		public async Task SetupDeleteAsync(
			DeleteUserClaimCommandRequest request,
			User user,
			UserClaim userClaim,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupDeleteUserClaimAsync(user, userClaim, request.Id, cancellationToken);
		}

		public async Task AddUserClaimCacheAsync(
			DeleteUserClaimCommandRequest request,
			UserClaim userClaim,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddUserClaimCacheAsync(userClaim, request.Id, cancellationToken);
		}

		public async Task SetupGetAllAsync(
			GetAllUserClaimsQueryRequest request,
			ICollection<User> users,
			ICollection<UserClaim> userClaims,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetAllUserClaimsAsync(users, userClaims, cancellationToken);
		}
	}
}
