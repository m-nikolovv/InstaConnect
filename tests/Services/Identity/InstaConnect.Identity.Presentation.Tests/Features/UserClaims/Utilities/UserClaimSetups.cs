using InstaConnect.Identity.Domain.Features.UserClaims.Models.Responses;
using InstaConnect.Identity.Domain.Features.UserClaims.Models.ValueObjects;
using InstaConnect.Identity.Presentation.Features.UserClaims.Controllers.v1;

namespace InstaConnect.Identity.Presentation.Tests.Features.UserClaims.Utilities;

public static class UserClaimSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public UserClaimController GetUserClaimController()
		{
			return serviceProvider.GetRequiredService<UserClaimController>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public UserClaimController GetUserClaimController()
		{
			return serviceScope.ServiceProvider.GetUserClaimController();
		}

		internal async Task<UserClaim?> GetByIdAsync(
		UserClaimIdApiResponse id,
		CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				new UserClaimId(new(id.Id), id.Claim),
				cancellationToken);
		}

		public async Task<UserClaim?> GetByIdAsync(
		AddUserClaimApiResponse response,
		CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				response.Response,
				cancellationToken);
		}

		public async Task<UserClaim?> GetByIdAsync(
		ActionResult<AddUserClaimApiResponse> response,
		CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				response.GetValue(),
				cancellationToken);
		}

		public async Task<UserClaimResponse?> GetUserClaimCacheByIdAsync(
			DeleteUserClaimApiRequest request,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetUserClaimCacheByIdAsync(request.Id, request.Claim, request.Id, cancellationToken);
		}

		public async Task InitializeAddAsync(
			AddUserClaimApiRequest request,
			UserClaim userClaim,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeAddAsync(userClaim, cancellationToken);
		}

		public async Task DisposeAddAsync(
			AddUserClaimApiRequest request,
			UserClaim userClaim,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeAddAsync(userClaim, cancellationToken);
		}

		public async Task InitializeDeleteAsync(
			DeleteUserClaimApiRequest request,
			UserClaim userClaim,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeDeleteAsync(userClaim, request.Id, cancellationToken);
		}

		public async Task DisposeDeleteAsync(
			DeleteUserClaimApiRequest request,
			UserClaim userClaim,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeDeleteAsync(userClaim, cancellationToken);
		}

		public async Task AddUserClaimCacheAsync(
			DeleteUserClaimApiRequest request,
			UserClaim userClaim,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddUserClaimCacheAsync(userClaim, request.Id, cancellationToken);
		}

		public async Task InitializeGetAllAsync(
			GetAllUserClaimsApiRequest request,
			ICollection<UserClaim> userClaims,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeGetAllAsync(userClaims, cancellationToken);
		}

		public async Task DisposeGetAllAsync(
			GetAllUserClaimsApiRequest request,
			ICollection<UserClaim> userClaims,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeGetAllAsync(userClaims, cancellationToken);
		}
	}
}
