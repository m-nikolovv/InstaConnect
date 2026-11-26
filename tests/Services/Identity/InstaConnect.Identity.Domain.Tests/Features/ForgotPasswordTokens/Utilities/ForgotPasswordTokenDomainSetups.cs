
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

		public async Task SetupAddAsync(
			AddForgotPasswordTokenCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupAddForgotPasswordTokenAsync(user, cancellationToken);
		}

		public async Task SetupVerifyAsync(
			VerifyForgotPasswordTokenCommand command,
			User user,
			ICollection<ForgotPasswordToken> forgotPasswordTokens,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupVerifyForgotPasswordTokenAsync(user, forgotPasswordTokens, command.Id.Id, cancellationToken);
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
