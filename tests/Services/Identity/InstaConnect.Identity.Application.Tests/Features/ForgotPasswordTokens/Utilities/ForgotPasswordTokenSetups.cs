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

		public async Task InitializeAddAsync(
			AddForgotPasswordTokenCommandRequest request,
			ForgotPasswordToken forgotPasswordToken,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeAddAsync(forgotPasswordToken, cancellationToken);
		}

		public async Task DisposeAddAsync(
			AddForgotPasswordTokenCommandRequest request,
			ForgotPasswordToken forgotPasswordToken,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeAddAsync(forgotPasswordToken, cancellationToken);
		}

		public async Task InitializeVerifyAsync(
			VerifyForgotPasswordTokenCommandRequest request,
			ForgotPasswordToken forgotPasswordToken,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeVerifyAsync(forgotPasswordToken, request.Id, cancellationToken);
		}

		public async Task DisposeVerifyAsync(
			VerifyForgotPasswordTokenCommandRequest request,
			ForgotPasswordToken forgotPasswordToken,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeVerifyAsync(forgotPasswordToken, cancellationToken);
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
