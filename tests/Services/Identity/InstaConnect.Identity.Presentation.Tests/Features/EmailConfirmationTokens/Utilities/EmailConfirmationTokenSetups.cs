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

		public async Task SetupAddAsync(
			AddEmailConfirmationTokenApiRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupAddEmailConfirmationTokenAsync(user, cancellationToken);
		}

		public async Task SetupVerifyAsync(
			VerifyEmailConfirmationTokenApiRequest request,
			User user,
			ICollection<EmailConfirmationToken> emailConfirmationTokens,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupVerifyEmailConfirmationTokenAsync(user, emailConfirmationTokens, request.Id, cancellationToken);
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
