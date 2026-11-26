using InstaConnect.Identity.Domain.Features.RefreshTokens.Abstractions;
using InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Abstractions;

namespace InstaConnect.Identity.Tests.Features.RefreshTokens.Utilities;

public static class RefreshTokenSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public IRefreshTokenCommandRepository GetRefreshTokenCommandRepository()
		{
			return serviceProvider.GetRequiredService<IRefreshTokenCommandRepository>();
		}

		public IRefreshTokenIncludeBuilderFactory GetRefreshTokenIncludeBuilderFactory()
		{
			return serviceProvider.GetRequiredService<IRefreshTokenIncludeBuilderFactory>();
		}

		public IRefreshTokenCollection GetRefreshTokenCollection()
		{
			return serviceProvider.GetRequiredService<IRefreshTokenCollection>();
		}

		public IRefreshTokenCacheHandler GetRefreshTokenCacheHandler()
		{
			return serviceProvider.GetRequiredService<IRefreshTokenCacheHandler>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public IRefreshTokenCommandRepository GetRefreshTokenCommandRepository()
		{
			return serviceScope.ServiceProvider.GetRefreshTokenCommandRepository();
		}

		public IRefreshTokenIncludeBuilderFactory GetRefreshTokenIncludeBuilderFactory()
		{
			return serviceScope.ServiceProvider.GetRefreshTokenIncludeBuilderFactory();
		}

		public IRefreshTokenCacheHandler GetRefreshTokenCacheHandler()
		{
			return serviceScope.ServiceProvider.GetRefreshTokenCacheHandler();
		}

		public async Task<RefreshToken?> GetByIdAsync(
			RefreshTokenId id,
			CancellationToken cancellationToken)
		{
			var refreshTokenInclude = serviceScope.GetRefreshTokenIncludeBuilderFactory().Create().WithUser().Build();

			return (await serviceScope.GetRefreshTokenCommandRepository().GetByIdAsync(id, refreshTokenInclude, cancellationToken)).SetUser();
		}

		public async Task<ICollection<RefreshToken>> GetByIdRangeAsync(
			IEnumerable<RefreshTokenId> ids,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetRefreshTokenCommandRepository().GetByIdRangeAsync(ids, cancellationToken);
		}

		public async Task AddAsync(
			RefreshToken refreshToken,
			CancellationToken cancellationToken)
		{
			var refreshTokenRepository = serviceScope.GetRefreshTokenCommandRepository();

			await refreshTokenRepository.AddAsync(refreshToken, cancellationToken);
		}

		public async Task AddRangeAsync(
			IEnumerable<RefreshToken> refreshTokens,
			CancellationToken cancellationToken)
		{
			var refreshTokenRepository = serviceScope.GetRefreshTokenCommandRepository();

			await refreshTokenRepository.AddRangeAsync(refreshTokens, cancellationToken);
		}

		public async Task UpdateAsync(
			RefreshToken refreshToken,
			CancellationToken cancellationToken)
		{
			var refreshTokenRepository = serviceScope.GetRefreshTokenCommandRepository();

			await refreshTokenRepository.UpdateAsync(refreshToken, cancellationToken);
		}

		public async Task DeleteAsync(
			RefreshToken refreshToken,
			CancellationToken cancellationToken)
		{
			var cacheHandler = serviceScope.GetRefreshTokenCacheHandler();
			var refreshTokenRepository = serviceScope.GetRefreshTokenCommandRepository();

			await refreshTokenRepository.DeleteAsync(refreshToken, cancellationToken);
			await cacheHandler.DeleteAsync(refreshToken.Id, cancellationToken);
		}

		public async Task SetupAddAsync(
			RefreshToken refreshToken,
			CancellationToken cancellationToken)
		{
			var user = refreshToken.User!;

			await serviceScope.AddAsync(user, cancellationToken);
		}

		public async Task SetupDeleteAsync(
			RefreshToken refreshToken,
			CancellationToken cancellationToken)
		{
			var user = refreshToken.User!;

			await serviceScope.AddAsync(user, cancellationToken);
			await serviceScope.AddAsync(refreshToken, cancellationToken);
		}

		public async Task SetupGetAllAsync(
			ICollection<RefreshToken> refreshTokens,
			CancellationToken cancellationToken)
		{
			var users = refreshTokens.Select(p => p.User!).DistinctBy(p => p.Id).ToList();

			await serviceScope.AddRangeAsync(users, cancellationToken);
			await serviceScope.AddRangeAsync(refreshTokens, cancellationToken);
		}

		public async Task SetupGetByIdAsync(
			RefreshToken refreshToken,
			CancellationToken cancellationToken)
		{
			var user = refreshToken.User!;

			await serviceScope.AddAsync(user, cancellationToken);
			await serviceScope.AddAsync(refreshToken, cancellationToken);
		}

		public async Task SetupUpdateAsync(
			RefreshToken refreshToken,
			CancellationToken cancellationToken)
		{
			var user = refreshToken.User!;

			await serviceScope.AddAsync(user, cancellationToken);
			await serviceScope.AddAsync(refreshToken, cancellationToken);
		}
	}
}
