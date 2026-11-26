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
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupAddRefreshTokenAsync(user, cancellationToken);
		}

		public async Task SetupDeleteAsync(
			DeleteRefreshTokenCommand command,
			User user,
			RefreshToken refreshToken,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupDeleteRefreshTokenAsync(user, refreshToken, cancellationToken);
		}

		public async Task SetupUpdateAsync(
			RotateRefreshTokenCommand command,
			User user,
			RefreshToken refreshToken,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupUpdateRefreshTokenAsync(user, refreshToken, cancellationToken);
		}
	}
}
