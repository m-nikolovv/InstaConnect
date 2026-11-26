using InstaConnect.Identity.Application.Features.Users.Models;
using InstaConnect.Identity.Domain.Features.Users.Models.Responses;

namespace InstaConnect.Identity.Application.Tests.Features.Users.Utilities;

public static class UserSetups
{
	extension(IServiceScope serviceScope)
	{
		internal async Task<User?> GetByIdAsync(
		UserIdCommandResponse id,
		CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				new UserId(id.Id),
				cancellationToken);
		}

		public async Task<User?> GetByIdAsync(
		AddUserCommandResponse response,
		CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				response.Response,
				cancellationToken);
		}

		public async Task<User?> GetByIdAsync(
		UpdateCurrentUserCommandResponse response,
		CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				response.Response,
				cancellationToken);
		}

		public async Task<UserResponse?> GetUserCacheByIdAsync(
			UpdateCurrentUserCommandRequest request,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetUserCacheByIdAsync(request.Id, request.Id, cancellationToken);
		}

		public async Task<UserResponse?> GetUserCacheByIdAsync(
			DeleteUserCommandRequest request,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetUserCacheByIdAsync(request.Id, request.Id, cancellationToken);
		}

		public async Task<UserResponse?> GetUserCacheByIdAsync(
			DeleteCurrentUserCommandRequest request,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetUserCacheByIdAsync(request.CurrentId, request.CurrentId, cancellationToken);
		}

		public async Task<UserResponse?> GetUserCacheByIdAsync(
			GetUserByIdQueryRequest request,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetUserCacheByIdAsync(request.Id, request.CurrentId, cancellationToken);
		}

		public async Task<UserResponse?> GetUserCacheByIdAsync(
			GetCurrentUserByIdQueryRequest request,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetUserCacheByIdAsync(request.CurrentId, request.CurrentId, cancellationToken);
		}

		public async Task<UserResponse?> GetUserCacheByIdAsync(
			GetUserDetailsByIdQueryRequest request,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetUserCacheByIdAsync(request.Id, request.CurrentId, cancellationToken);
		}

		public async Task<UserResponse?> GetUserCacheByIdAsync(
			GetCurrentUserDetailsByIdQueryRequest request,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetUserCacheByIdAsync(request.CurrentId, request.CurrentId, cancellationToken);
		}

		public async Task SetupAddAsync(
			AddUserCommandRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupAddUserAsync(user, cancellationToken);
		}

		public async Task SetupDeleteAsync(
			DeleteCurrentUserCommandRequest request,
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
			DeleteUserCommandRequest request,
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
			DeleteCurrentUserCommandRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddUserCacheAsync(user, request.CurrentId, cancellationToken);
		}

		public async Task AddUserCacheAsync(
			DeleteUserCommandRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddUserCacheAsync(user, request.Id, cancellationToken);
		}

		public async Task AddUserCacheAsync(
			UpdateCurrentUserCommandRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddUserCacheAsync(user, request.Id, cancellationToken);
		}

		public async Task SetupGetAllAsync(
			GetAllUsersQueryRequest request,
			ICollection<User> users,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetAllUsersAsync(users, cancellationToken);
		}

		public async Task SetupGetByIdAsync(
			GetCurrentUserByIdQueryRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetUserByIdAsync(user, cancellationToken);
		}

		public async Task SetupGetByIdAsync(
			GetCurrentUserDetailsByIdQueryRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetUserByIdAsync(user, cancellationToken);
		}

		public async Task SetupGetByIdAsync(
			GetUserByIdQueryRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetUserByIdAsync(user, cancellationToken);
		}

		public async Task SetupGetByIdAsync(
			GetUserDetailsByIdQueryRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetUserByIdAsync(user, cancellationToken);
		}




		public async Task SetupUpdateAsync(
			UpdateCurrentUserCommandRequest request,
			User user,
			ICollection<EmailConfirmationToken> emailConfirmationTokens,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupUpdateUserAsync(user, emailConfirmationTokens, request.Id, cancellationToken);
		}
	}
}
