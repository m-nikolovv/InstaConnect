using InstaConnect.Identity.Domain.Features.Users.Models.Responses;

namespace InstaConnect.Identity.Application.Tests.Features.EmailConfirmationTokens.Utilities;

public static class EmailConfirmationTokenSetups
{
	extension(IServiceScope serviceScope)
	{
		public async Task<UserResponse?> GetUserCacheByIdAsync(
			VerifyEmailConfirmationTokenCommandRequest request,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetUserCacheByIdAsync(request.Id, request.Id, cancellationToken);
		}

		public async Task SetupAddAsync(
			AddEmailConfirmationTokenCommandRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupAddEmailConfirmationTokenAsync(user, cancellationToken);
		}

		public async Task SetupVerifyAsync(
			VerifyEmailConfirmationTokenCommandRequest request,
			User user,
			ICollection<EmailConfirmationToken> emailConfirmationTokens,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupVerifyEmailConfirmationTokenAsync(user, emailConfirmationTokens, request.Id, cancellationToken);
		}

		public async Task AddUserCacheAsync(
			VerifyEmailConfirmationTokenCommandRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddUserCacheAsync(user, request.Id, cancellationToken);
		}
	}

}
