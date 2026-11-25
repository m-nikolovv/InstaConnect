using InstaConnect.Identity.Domain.Features.UserClaims.Abstractions;
using InstaConnect.Identity.Domain.Features.UserClaims.Models.Responses;
using InstaConnect.Identity.Infrastructure.Features.UserClaims.Abstractions;

namespace InstaConnect.Identity.Tests.Features.UserClaims.Utilities;

public static class UserClaimSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public IUserClaimQueryRepository GetClaimQueryRepository()
		{
			return serviceProvider.GetRequiredService<IUserClaimQueryRepository>();
		}

		public IUserClaimCommandRepository GetClaimCommandRepository()
		{
			return serviceProvider.GetRequiredService<IUserClaimCommandRepository>();
		}

		public IUserClaimIncludeBuilderFactory GetClaimIncludeBuilderFactory()
		{
			return serviceProvider.GetRequiredService<IUserClaimIncludeBuilderFactory>();
		}

		public IUserClaimCollection GetClaimCollection()
		{
			return serviceProvider.GetRequiredService<IUserClaimCollection>();
		}

		public IUserClaimCacheHandler GetClaimCacheHandler()
		{
			return serviceProvider.GetRequiredService<IUserClaimCacheHandler>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public IUserClaimQueryRepository GetClaimQueryRepository()
		{
			return serviceScope.ServiceProvider.GetClaimQueryRepository();
		}

		public IUserClaimCommandRepository GetClaimCommandRepository()
		{
			return serviceScope.ServiceProvider.GetClaimCommandRepository();
		}

		public IUserClaimIncludeBuilderFactory GetClaimIncludeBuilderFactory()
		{
			return serviceScope.ServiceProvider.GetClaimIncludeBuilderFactory();
		}

		public IUserClaimCacheHandler GetClaimCacheHandler()
		{
			return serviceScope.ServiceProvider.GetClaimCacheHandler();
		}

		public async Task<UserClaim?> GetByIdAsync(
			UserClaimId id,
			CancellationToken cancellationToken)
		{
			var claimInclude = serviceScope.GetClaimIncludeBuilderFactory().Create().WithUser().Build();

			return (await serviceScope.GetClaimCommandRepository().GetByIdAsync(id, claimInclude, cancellationToken)).SetUser();
		}

		public async Task<ICollection<UserClaim>> GetByIdRangeAsync(
			IEnumerable<UserClaimId> ids,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetClaimCommandRepository().GetByIdRangeAsync(ids, cancellationToken);
		}

		public async Task AddAsync(
			UserClaim userClaim,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			var cacheHandler = serviceScope.GetClaimCacheHandler();
			var claimRepository = serviceScope.GetClaimCommandRepository();

			await claimRepository.AddAsync(userClaim, cancellationToken);
			await cacheHandler.AddAsync(userClaim.ToFullResponse(), currentUserId, cancellationToken);
		}

		public async Task AddRangeAsync(
			ICollection<UserClaim> userClaims,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			var cacheHandler = serviceScope.GetClaimCacheHandler();
			var claimRepository = serviceScope.GetClaimCommandRepository();

			await claimRepository.AddRangeAsync(userClaims, cancellationToken);
			await cacheHandler.AddRangeAsync(userClaims.ToFullResponse(), currentUserId, cancellationToken);
		}

		public async Task DeleteAsync(
			UserClaim userClaim,
			CancellationToken cancellationToken)
		{
			var cacheHandler = serviceScope.GetClaimCacheHandler();
			var claimRepository = serviceScope.GetClaimCommandRepository();

			await claimRepository.DeleteAsync(userClaim, cancellationToken);
			await cacheHandler.DeleteAsync(userClaim.Id, cancellationToken);
		}
	}

	extension(IUserClaimCacheHandler cacheHandler)
	{
		public async Task<UserClaimResponse?> GetByIdAsync(
			string id,
			ApplicationClaims claim,
			string currentUserId,
			CancellationToken cancellationToken)
		{
			return await cacheHandler.GetByIdAsync(new(new(id), claim), new(currentUserId), cancellationToken);
		}
	}
}
