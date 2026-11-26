using InstaConnect.Identity.Domain.Features.Users.Models.Responses;
using InstaConnect.Identity.Presentation.Features.EmailConfirmationTokens.Controllers.v1;

namespace InstaConnect.Identity.Presentation.Tests.Features.EmailConfirmationTokens.Utilities;

public static class EmailConfirmationTokenSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public EmailConfirmationTokenController GetEmailConfirmationTokenController()
		{
			return serviceProvider.GetRequiredService<EmailConfirmationTokenController>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public EmailConfirmationTokenController GetEmailConfirmationTokenController()
		{
			return serviceScope.ServiceProvider.GetEmailConfirmationTokenController();
		}

		public async Task<UserResponse?> GetUserCacheByIdAsync(
			VerifyEmailConfirmationTokenApiRequest request,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetUserCacheByIdAsync(request.Id, request.Id, cancellationToken);
		}

		public async Task InitializeAddAsync(
			AddEmailConfirmationTokenApiRequest request,
			EmailConfirmationToken emailConfirmationToken,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeAddAsync(emailConfirmationToken, cancellationToken);
		}

		public async Task DisposeAddAsync(
			AddEmailConfirmationTokenApiRequest request,
			EmailConfirmationToken emailConfirmationToken,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeAddAsync(emailConfirmationToken, cancellationToken);
		}

		public async Task InitializeVerifyAsync(
			VerifyEmailConfirmationTokenApiRequest request,
			EmailConfirmationToken emailConfirmationToken,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeVerifyAsync(emailConfirmationToken, request.Id, cancellationToken);
		}

		public async Task DisposeVerifyAsync(
			VerifyEmailConfirmationTokenApiRequest request,
			EmailConfirmationToken emailConfirmationToken,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeVerifyAsync(emailConfirmationToken, cancellationToken);
		}

		public async Task AddUserCacheAsync(
			VerifyEmailConfirmationTokenApiRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddUserCacheAsync(user, request.Id, cancellationToken);
		}
	}
}
