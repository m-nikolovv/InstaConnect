using InstaConnect.Identity.Domain.Features.UserClaims.Models.Responses;

namespace InstaConnect.Identity.Domain.Tests.Features.UserClaims.Utilities;

public static class UserClaimDomainSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public IUserClaimCommandService GetClaimCommandService()
		{
			return serviceProvider.GetRequiredService<IUserClaimCommandService>();
		}

		public IUserClaimQueryService GetClaimQueryService()
		{
			return serviceProvider.GetRequiredService<IUserClaimQueryService>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public IUserClaimCommandService GetClaimCommandService()
		{
			return serviceScope.ServiceProvider.GetClaimCommandService();
		}

		public IUserClaimQueryService GetClaimQueryService()
		{
			return serviceScope.ServiceProvider.GetClaimQueryService();
		}

		public async Task<UserClaimResponse?> GetUserClaimCacheByIdAsync(
			DeleteUserClaimCommand command,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetUserClaimCacheByIdAsync(command.Id, command.Id.Id, cancellationToken);
		}

		public async Task SetupAddAsync(
			AddUserClaimCommand command,
			UserClaim userClaim,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupAddAsync(userClaim, cancellationToken);
		}

		public async Task SetupDeleteAsync(
			DeleteUserClaimCommand command,
			UserClaim userClaim,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupDeleteAsync(userClaim, command.Id.Id, cancellationToken);
		}

		public async Task AddUserClaimCacheAsync(
			DeleteUserClaimCommand command,
			UserClaim userClaim,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddUserClaimCacheAsync(userClaim, command.Id.Id, cancellationToken);
		}

		public async Task SetupGetAllAsync(
			GetAllUserClaimsQuery query,
			ICollection<UserClaim> userClaims,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetAllAsync(userClaims, cancellationToken);
		}
	}
}
