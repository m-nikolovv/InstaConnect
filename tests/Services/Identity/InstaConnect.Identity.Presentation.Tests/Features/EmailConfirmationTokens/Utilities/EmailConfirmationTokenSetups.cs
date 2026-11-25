using InstaConnect.Identity.Domain.Features.Users.Models.Responses;
using InstaConnect.Identity.Infrastructure.Features.Users.Abstractions;
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
	}

	extension(IUserCacheHandler cacheHandler)
	{
		public async Task<UserResponse?> GetByIdAsync(
			VerifyEmailConfirmationTokenApiRequest request,
			CancellationToken cancellationToken)
		{
			return await cacheHandler.GetByIdAsync(request.Id, request.Id, cancellationToken);
		}
	}
}
