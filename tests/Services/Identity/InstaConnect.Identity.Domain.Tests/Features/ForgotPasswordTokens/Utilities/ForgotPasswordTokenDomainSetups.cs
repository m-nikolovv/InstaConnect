using InstaConnect.Identity.Infrastructure.Features.Users.Abstractions;

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
	}

	extension(IUserCacheHandler cacheHandler)
	{
		public async Task<UserResponse?> GetByIdAsync(
			VerifyForgotPasswordTokenCommand command,
			CancellationToken cancellationToken)
		{
			return await cacheHandler.GetByIdAsync(command.Id.Id, command.Id.Id, cancellationToken);
		}
	}
}
