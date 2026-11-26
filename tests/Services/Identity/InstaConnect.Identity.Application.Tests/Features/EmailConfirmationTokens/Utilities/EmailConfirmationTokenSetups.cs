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

		public async Task InitializeAddAsync(
			AddEmailConfirmationTokenCommandRequest request,
			EmailConfirmationToken emailConfirmationToken,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeAddAsync(emailConfirmationToken, cancellationToken);
		}

		public async Task DisposeAddAsync(
			AddEmailConfirmationTokenCommandRequest request,
			EmailConfirmationToken emailConfirmationToken,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeAddAsync(emailConfirmationToken, cancellationToken);
		}

		public async Task InitializeVerifyAsync(
			VerifyEmailConfirmationTokenCommandRequest request,
			EmailConfirmationToken emailConfirmationToken,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeVerifyAsync(emailConfirmationToken, request.Id, cancellationToken);
		}

		public async Task DisposeVerifyAsync(
			VerifyEmailConfirmationTokenCommandRequest request,
			EmailConfirmationToken emailConfirmationToken,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeVerifyAsync(emailConfirmationToken, cancellationToken);
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
