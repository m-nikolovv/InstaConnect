namespace InstaConnect.Identity.Domain.Tests.Features.RefreshTokens.Utilities;

public static class RefreshTokenDomainSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public IRefreshTokenCommandService GetRefreshTokenCommandService()
		{
			return serviceProvider.GetRequiredService<IRefreshTokenCommandService>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public IRefreshTokenCommandService GetRefreshTokenCommandService()
		{
			return serviceScope.ServiceProvider.GetRefreshTokenCommandService();
		}

		public async Task InitializeAddAsync(
			IssueRefreshTokenCommand command,
			RefreshToken refreshToken,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeAddAsync(refreshToken, cancellationToken);
		}

		public async Task DisposeAddAsync(
			IssueRefreshTokenCommand command,
			RefreshToken refreshToken,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeAddAsync(refreshToken, cancellationToken);
		}

		public async Task InitializeDeleteAsync(
			DeleteRefreshTokenCommand command,
			RefreshToken refreshToken,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeDeleteAsync(refreshToken, cancellationToken);
		}

		public async Task DisposeDeleteAsync(
			DeleteRefreshTokenCommand command,
			RefreshToken refreshToken,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeDeleteAsync(refreshToken, cancellationToken);
		}

		public async Task InitializeUpdateAsync(
			RotateRefreshTokenCommand command,
			RefreshToken refreshToken,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeUpdateAsync(refreshToken, cancellationToken);
		}

		public async Task DisposeUpdateAsync(
			RotateRefreshTokenCommand command,
			RefreshToken refreshToken,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeUpdateAsync(refreshToken, cancellationToken);
		}
	}
}
