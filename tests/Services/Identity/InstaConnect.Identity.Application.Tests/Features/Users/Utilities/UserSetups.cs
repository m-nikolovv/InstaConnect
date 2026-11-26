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

		public async Task InitializeAddAsync(
			AddUserCommandRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeAddAsync(user, cancellationToken);
		}

		public async Task DisposeAddAsync(
			AddUserCommandRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeAddAsync(user, cancellationToken);
		}

		public async Task InitializeDeleteAsync(
			DeleteCurrentUserCommandRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeDeleteAsync(user, request.CurrentId, cancellationToken);
		}

		public async Task InitializeDeleteAsync(
			DeleteUserCommandRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeDeleteAsync(user, request.Id, cancellationToken);
		}

		public async Task DisposeDeleteAsync(
			DeleteCurrentUserCommandRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeDeleteAsync(user, cancellationToken);
		}

		public async Task DisposeDeleteAsync(
			DeleteUserCommandRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeDeleteAsync(user, cancellationToken);
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

		public async Task InitializeGetAllAsync(
			GetAllUsersQueryRequest request,
			ICollection<User> users,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeGetAllAsync(users, cancellationToken);
		}

		public async Task DisposeGetAllAsync(
			GetAllUsersQueryRequest request,
			ICollection<User> users,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeGetAllAsync(users, cancellationToken);
		}

		public async Task InitializeGetByIdAsync(
			GetCurrentUserByIdQueryRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeGetByIdAsync(user, cancellationToken);
		}

		public async Task InitializeGetByIdAsync(
			GetCurrentUserDetailsByIdQueryRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeGetByIdAsync(user, cancellationToken);
		}

		public async Task InitializeGetByIdAsync(
			GetUserByIdQueryRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeGetByIdAsync(user, cancellationToken);
		}

		public async Task InitializeGetByIdAsync(
			GetUserDetailsByIdQueryRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeGetByIdAsync(user, cancellationToken);
		}

		public async Task DisposeGetByIdAsync(
			GetCurrentUserByIdQueryRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeGetByIdAsync(user, cancellationToken);
		}

		public async Task DisposeGetByIdAsync(
			GetCurrentUserDetailsByIdQueryRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeGetByIdAsync(user, cancellationToken);
		}

		public async Task DisposeGetByIdAsync(
			GetUserByIdQueryRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeGetByIdAsync(user, cancellationToken);
		}

		public async Task DisposeGetByIdAsync(
			GetUserDetailsByIdQueryRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeGetByIdAsync(user, cancellationToken);
		}

		public async Task InitializeUpdateAsync(
			UpdateCurrentUserCommandRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeUpdateAsync(user, request.Id, cancellationToken);
		}

		public async Task DisposeUpdateAsync(
			UpdateCurrentUserCommandRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeUpdateAsync(user, cancellationToken);
		}
	}
}
