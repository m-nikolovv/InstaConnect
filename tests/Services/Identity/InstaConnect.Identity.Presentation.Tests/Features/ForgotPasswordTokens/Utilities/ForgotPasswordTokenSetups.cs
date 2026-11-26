using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Entities;
using InstaConnect.Identity.Domain.Features.Users.Models.Responses;
using InstaConnect.Identity.Presentation.Features.ForgotPasswordTokens.Controllers.v1;

namespace InstaConnect.Identity.Presentation.Tests.Features.ForgotPasswordTokens.Utilities;

public static class ForgotPasswordTokenSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public ForgotPasswordTokenController GetForgotPasswordTokenController()
		{
			return serviceProvider.GetRequiredService<ForgotPasswordTokenController>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public ForgotPasswordTokenController GetForgotPasswordTokenController()
		{
			return serviceScope.ServiceProvider.GetForgotPasswordTokenController();
		}

		public async Task<UserResponse?> GetUserCacheByIdAsync(
			VerifyForgotPasswordTokenApiRequest request,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetUserCacheByIdAsync(request.Id, request.Id, cancellationToken);
		}

		public async Task InitializeAddAsync(
			AddForgotPasswordTokenApiRequest request,
			ForgotPasswordToken forgotPasswordToken,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeAddAsync(forgotPasswordToken, cancellationToken);
		}

		public async Task DisposeAddAsync(
			AddForgotPasswordTokenApiRequest request,
			ForgotPasswordToken forgotPasswordToken,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeAddAsync(forgotPasswordToken, cancellationToken);
		}

		public async Task InitializeVerifyAsync(
			VerifyForgotPasswordTokenApiRequest request,
			ForgotPasswordToken forgotPasswordToken,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeVerifyAsync(forgotPasswordToken, request.Id, cancellationToken);
		}

		public async Task DisposeVerifyAsync(
			VerifyForgotPasswordTokenApiRequest request,
			ForgotPasswordToken forgotPasswordToken,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeVerifyAsync(forgotPasswordToken, cancellationToken);
		}

		public async Task AddUserCacheAsync(
			VerifyForgotPasswordTokenApiRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddUserCacheAsync(user, request.Id, cancellationToken);
		}
	}
}
