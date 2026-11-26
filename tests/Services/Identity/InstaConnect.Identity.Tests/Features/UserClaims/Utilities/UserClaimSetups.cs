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
			CancellationToken cancellationToken)
		{
			var claimRepository = serviceScope.GetClaimCommandRepository();

			await claimRepository.AddAsync(userClaim, cancellationToken);
		}

		public async Task AddRangeAsync(
			ICollection<UserClaim> userClaims,
			CancellationToken cancellationToken)
		{
			var claimRepository = serviceScope.GetClaimCommandRepository();

			await claimRepository.AddRangeAsync(userClaims, cancellationToken);
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

		public async Task<UserClaimResponse?> GetUserClaimCacheByIdAsync(
			string id,
			ApplicationClaims claim,
			string currentUserId,
			CancellationToken cancellationToken)
		{
			var cacheHandler = serviceScope.GetClaimCacheHandler();

			return await cacheHandler.GetByIdAsync(new(new(id), claim), new(currentUserId), cancellationToken);
		}

		public async Task<UserClaimResponse?> GetUserClaimCacheByIdAsync(
			UserClaimId id,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			var cacheHandler = serviceScope.GetClaimCacheHandler();

			return await cacheHandler.GetByIdAsync(id, currentUserId, cancellationToken);
		}

		public async Task SetupAddAsync(
			UserClaim userClaim,
			CancellationToken cancellationToken)
		{
			var user = userClaim.User!;

			await serviceScope.AddAsync(user, cancellationToken);
		}

		public async Task SetupDeleteAsync(
			UserClaim userClaim,
			string currentUserId,
			CancellationToken cancellationToken)
		{
			var user = userClaim.User!;

			await serviceScope.AddAsync(user, cancellationToken);
			await serviceScope.AddAsync(userClaim, cancellationToken);
			await serviceScope.AddUserClaimCacheAsync(userClaim, currentUserId, cancellationToken);
		}

		public async Task SetupDeleteAsync(
			UserClaim userClaim,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupDeleteAsync(userClaim, currentUserId.Id, cancellationToken);
		}

		public async Task SetupGetAllAsync(
			ICollection<UserClaim> userClaims,
			CancellationToken cancellationToken)
		{
			var users = userClaims.Select(p => p.User!).DistinctBy(p => p.Id).ToList();

			await serviceScope.AddRangeAsync(users, cancellationToken);
			await serviceScope.AddRangeAsync(userClaims, cancellationToken);
		}

		public async Task SetupGetByIdAsync(
			UserClaim userClaim,
			CancellationToken cancellationToken)
		{
			var user = userClaim.User!;

			await serviceScope.AddAsync(user, cancellationToken);
			await serviceScope.AddAsync(userClaim, cancellationToken);
		}

		public async Task AddUserClaimCacheAsync(
			UserClaim userClaim,
			string currentUserId,
			CancellationToken cancellationToken)
		{
			var cacheHandler = serviceScope.GetClaimCacheHandler();

			await cacheHandler.AddAsync(userClaim.ToFullResponse(), new(currentUserId), cancellationToken);
		}

		public async Task AddUserClaimCacheAsync(
			UserClaim userClaim,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddUserClaimCacheAsync(userClaim, currentUserId.Id, cancellationToken);
		}
	}
}
