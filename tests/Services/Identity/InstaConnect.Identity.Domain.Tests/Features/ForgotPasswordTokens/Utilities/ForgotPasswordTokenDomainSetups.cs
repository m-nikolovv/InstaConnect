
namespace InstaConnect.Identity.Domain.Tests.Features.ForgotPasswordTokens.Utilities;

public static class ForgotPasswordTokenDomainSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public IForgotPasswordTokenCommandService GetForgotPasswordTokenCommandService()
		{
			return serviceProvider.GetRequiredService<IForgotPasswordTokenCommandService>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public IForgotPasswordTokenCommandService GetForgotPasswordTokenCommandService()
		{
			return serviceScope.ServiceProvider.GetForgotPasswordTokenCommandService();
		}

		public async Task<UserResponse?> GetUserCacheByIdAsync(
			VerifyForgotPasswordTokenCommand command,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetUserCacheByIdAsync(command.Id.Id, command.Id.Id, cancellationToken);
		}

		public async Task InitializeAddAsync(
			AddForgotPasswordTokenCommand command,
			ForgotPasswordToken forgotPasswordToken,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeAddAsync(forgotPasswordToken, cancellationToken);
		}

		public async Task DisposeAddAsync(
			AddForgotPasswordTokenCommand command,
			ForgotPasswordToken forgotPasswordToken,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeAddAsync(forgotPasswordToken, cancellationToken);
		}

		public async Task InitializeVerifyAsync(
			VerifyForgotPasswordTokenCommand command,
			ForgotPasswordToken forgotPasswordToken,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeVerifyAsync(forgotPasswordToken, command.Id.Id, cancellationToken);
		}

		public async Task DisposeVerifyAsync(
			VerifyForgotPasswordTokenCommand command,
			ForgotPasswordToken forgotPasswordToken,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeVerifyAsync(forgotPasswordToken, cancellationToken);
		}

		public async Task AddUserCacheAsync(
			VerifyForgotPasswordTokenCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddUserCacheAsync(user, command.Id.Id, cancellationToken);
		}
	}
}
