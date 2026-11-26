using InstaConnect.Identity.Domain.Features.Users.Models.Responses;

namespace InstaConnect.Identity.Application.Tests.Features.ForgotPasswordTokens.Utilities;

public static class ForgotPasswordTokenSetups
{
	extension(IServiceScope serviceScope)
	{
		public async Task<UserResponse?> GetUserCacheByIdAsync(
			VerifyForgotPasswordTokenCommandRequest request,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetUserCacheByIdAsync(request.Id, request.Id, cancellationToken);
		}

		public async Task SetupAddAsync(
			AddForgotPasswordTokenCommandRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupAddForgotPasswordTokenAsync(user, cancellationToken);
		}

		public async Task SetupVerifyAsync(
			VerifyForgotPasswordTokenCommandRequest request,
			User user,
			ICollection<ForgotPasswordToken> forgotPasswordTokens,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupVerifyForgotPasswordTokenAsync(user, forgotPasswordTokens, request.Id, cancellationToken);
		}

		public async Task AddUserCacheAsync(
			VerifyForgotPasswordTokenCommandRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddUserCacheAsync(user, request.Id, cancellationToken);
		}
	}

}
