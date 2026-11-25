using InstaConnect.Identity.Domain.Features.UserClaims.Models.Responses;
using InstaConnect.Identity.Infrastructure.Features.UserClaims.Abstractions;

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
	}

	extension(IUserClaimCacheHandler cacheHandler)
	{
		public async Task<UserClaimResponse?> GetByIdAsync(
			DeleteUserClaimCommand command,
			CancellationToken cancellationToken)
		{
			return await cacheHandler.GetByIdAsync(command.Id, command.Id.Id, cancellationToken);
		}
	}
}
