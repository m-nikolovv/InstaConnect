using InstaConnect.Identity.Application.Features.UserClaims.Models;
using InstaConnect.Identity.Domain.Features.UserClaims.Models.Responses;
using InstaConnect.Identity.Domain.Features.UserClaims.Models.ValueObjects;
using InstaConnect.Identity.Infrastructure.Features.UserClaims.Abstractions;

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
	}

	extension(IUserClaimCacheHandler cacheHandler)
	{
		public async Task<UserClaimResponse?> GetByIdAsync(
			DeleteUserClaimCommandRequest request,
			CancellationToken cancellationToken)
		{
			return await cacheHandler.GetByIdAsync(request.Id, request.Claim, request.Id, cancellationToken);
		}
	}
}
