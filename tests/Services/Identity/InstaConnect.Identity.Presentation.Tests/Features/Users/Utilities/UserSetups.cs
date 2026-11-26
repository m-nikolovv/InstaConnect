using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Entities;
using InstaConnect.Identity.Domain.Features.Users.Models.Responses;
using InstaConnect.Identity.Presentation.Features.Users.Controllers.v1;

namespace InstaConnect.Identity.Presentation.Tests.Features.Users.Utilities;

public static class UserSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public UserController GetUserController()
		{
			return serviceProvider.GetRequiredService<UserController>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public UserController GetUserController()
		{
			return serviceScope.ServiceProvider.GetUserController();
		}

		internal async Task<User?> GetByIdAsync(
		UserIdApiResponse id,
		CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				new UserId(id.Id),
				cancellationToken);
		}

		public async Task<User?> GetByIdAsync(
		AddUserApiResponse response,
		CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				response.Response,
				cancellationToken);
		}

		public async Task<User?> GetByIdAsync(
		UpdateCurrentUserApiResponse response,
		CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				response.Response,
				cancellationToken);
		}

		public async Task<User?> GetByIdAsync(
		ActionResult<AddUserApiResponse> response,
		CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				response.GetValue(),
				cancellationToken);
		}

		public async Task<User?> GetByIdAsync(
		ActionResult<UpdateCurrentUserApiResponse> response,
		CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				response.GetValue(),
				cancellationToken);
		}

		public async Task<UserResponse?> GetUserCacheByIdAsync(
			UpdateCurrentUserApiRequest request,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetUserCacheByIdAsync(request.Id, request.Id, cancellationToken);
		}

		public async Task<UserResponse?> GetUserCacheByIdAsync(
			DeleteUserApiRequest request,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetUserCacheByIdAsync(request.Id, request.Id, cancellationToken);
		}

		public async Task<UserResponse?> GetUserCacheByIdAsync(
			DeleteCurrentUserApiRequest request,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetUserCacheByIdAsync(request.CurrentId, request.CurrentId, cancellationToken);
		}

		public async Task<UserResponse?> GetUserCacheByIdAsync(
			GetUserByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetUserCacheByIdAsync(request.Id, request.CurrentId, cancellationToken);
		}

		public async Task<UserResponse?> GetUserCacheByIdAsync(
			GetCurrentUserByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetUserCacheByIdAsync(request.CurrentId, request.CurrentId, cancellationToken);
		}

		public async Task<UserResponse?> GetUserCacheByIdAsync(
			GetUserDetailsByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetUserCacheByIdAsync(request.Id, request.CurrentId, cancellationToken);
		}

		public async Task<UserResponse?> GetUserCacheByIdAsync(
			GetCurrentUserDetailsByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetUserCacheByIdAsync(request.CurrentId, request.CurrentId, cancellationToken);
		}

		public async Task SetupAddAsync(
			AddUserApiRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupAddUserAsync(user, cancellationToken);
		}

		public async Task SetupDeleteAsync(
			DeleteCurrentUserApiRequest request,
			User user,
			ICollection<UserClaim> userClaims,
			ICollection<RefreshToken> refreshTokens,
			ICollection<ForgotPasswordToken> forgotPasswordTokens,
			ICollection<EmailConfirmationToken> emailConfirmationTokens,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupDeleteUserAsync(user, userClaims, refreshTokens, forgotPasswordTokens, emailConfirmationTokens, request.CurrentId, cancellationToken);
		}

		public async Task SetupDeleteAsync(
			DeleteUserApiRequest request,
			User user,
			ICollection<UserClaim> userClaims,
			ICollection<RefreshToken> refreshTokens,
			ICollection<ForgotPasswordToken> forgotPasswordTokens,
			ICollection<EmailConfirmationToken> emailConfirmationTokens,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupDeleteUserAsync(user, userClaims, refreshTokens, forgotPasswordTokens, emailConfirmationTokens, request.Id, cancellationToken);
		}


		public async Task AddUserCacheAsync(
			DeleteCurrentUserApiRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddUserCacheAsync(user, request.CurrentId, cancellationToken);
		}

		public async Task AddUserCacheAsync(
			DeleteUserApiRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddUserCacheAsync(user, request.Id, cancellationToken);
		}

		public async Task AddUserCacheAsync(
			UpdateCurrentUserApiRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddUserCacheAsync(user, request.Id, cancellationToken);
		}

		public async Task SetupGetAllAsync(
			GetAllUsersApiRequest request,
			ICollection<User> users,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetAllUsersAsync(users, cancellationToken);
		}

		public async Task SetupGetByIdAsync(
			GetCurrentUserByIdApiRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetUserByIdAsync(user, cancellationToken);
		}

		public async Task SetupGetByIdAsync(
			GetCurrentUserDetailsByIdApiRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetUserByIdAsync(user, cancellationToken);
		}

		public async Task SetupGetByIdAsync(
			GetUserByIdApiRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetUserByIdAsync(user, cancellationToken);
		}

		public async Task SetupGetByIdAsync(
			GetUserDetailsByIdApiRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetUserByIdAsync(user, cancellationToken);
		}




		public async Task SetupUpdateAsync(
			UpdateCurrentUserApiRequest request,
			User user,
			ICollection<EmailConfirmationToken> emailConfirmationTokens,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupUpdateUserAsync(user, emailConfirmationTokens, request.Id, cancellationToken);
		}
	}
}
