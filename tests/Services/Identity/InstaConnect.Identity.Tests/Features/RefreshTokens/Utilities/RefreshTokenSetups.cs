using InstaConnect.Identity.Domain.Features.RefreshTokens.Abstractions;

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

		public async Task<RefreshToken?> GetByIdAsync(
			RefreshTokenId id,
			CancellationToken cancellationToken)
		{
			var refreshTokenInclude = serviceScope.GetRefreshTokenIncludeBuilderFactory().Create().WithUser().Build();

			return (await serviceScope.GetRefreshTokenCommandRepository().GetByIdAsync(id, refreshTokenInclude, cancellationToken)).SetUser();
		}

		public async Task AddAsync(
			RefreshToken refreshToken,
			CancellationToken cancellationToken)
		{
			await serviceScope.GetRefreshTokenCommandRepository().AddAsync(refreshToken, cancellationToken);
		}

		public async Task AddRangeAsync(
			IEnumerable<RefreshToken> refreshTokens,
			CancellationToken cancellationToken)
		{
			await serviceScope.GetRefreshTokenCommandRepository().AddRangeAsync(refreshTokens, cancellationToken);
		}

		public async Task UpdateAsync(
			RefreshToken refreshToken,
			CancellationToken cancellationToken)
		{
			await serviceScope.GetRefreshTokenCommandRepository().UpdateAsync(refreshToken, cancellationToken);
		}

		public async Task DeleteAsync(
			RefreshToken refreshToken,
			CancellationToken cancellationToken)
		{
			await serviceScope.GetRefreshTokenCommandRepository().DeleteAsync(refreshToken, cancellationToken);
		}
	}
}

