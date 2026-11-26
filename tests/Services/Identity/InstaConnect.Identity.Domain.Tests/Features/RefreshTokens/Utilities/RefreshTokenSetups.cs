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

		public async Task SetupAddAsync(
			IssueRefreshTokenCommand command,
			RefreshToken refreshToken,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupAddAsync(refreshToken, cancellationToken);
		}

		public async Task SetupDeleteAsync(
			DeleteRefreshTokenCommand command,
			RefreshToken refreshToken,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupDeleteAsync(refreshToken, cancellationToken);
		}

		public async Task SetupUpdateAsync(
			RotateRefreshTokenCommand command,
			RefreshToken refreshToken,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupUpdateAsync(refreshToken, cancellationToken);
		}
	}
}
