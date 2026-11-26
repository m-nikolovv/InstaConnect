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

		public async Task InitializeAddAsync(
			AddUserApiRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeAddAsync(user, cancellationToken);
		}

		public async Task DisposeAddAsync(
			AddUserApiRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeAddAsync(user, cancellationToken);
		}

		public async Task InitializeDeleteAsync(
			DeleteCurrentUserApiRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeDeleteAsync(user, request.CurrentId, cancellationToken);
		}

		public async Task InitializeDeleteAsync(
			DeleteUserApiRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeDeleteAsync(user, request.Id, cancellationToken);
		}

		public async Task DisposeDeleteAsync(
			DeleteCurrentUserApiRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeDeleteAsync(user, cancellationToken);
		}

		public async Task DisposeDeleteAsync(
			DeleteUserApiRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeDeleteAsync(user, cancellationToken);
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

		public async Task InitializeGetAllAsync(
			GetAllUsersApiRequest request,
			ICollection<User> users,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeGetAllAsync(users, cancellationToken);
		}

		public async Task DisposeGetAllAsync(
			GetAllUsersApiRequest request,
			ICollection<User> users,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeGetAllAsync(users, cancellationToken);
		}

		public async Task InitializeGetByIdAsync(
			GetCurrentUserByIdApiRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeGetByIdAsync(user, cancellationToken);
		}

		public async Task InitializeGetByIdAsync(
			GetCurrentUserDetailsByIdApiRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeGetByIdAsync(user, cancellationToken);
		}

		public async Task InitializeGetByIdAsync(
			GetUserByIdApiRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeGetByIdAsync(user, cancellationToken);
		}

		public async Task InitializeGetByIdAsync(
			GetUserDetailsByIdApiRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeGetByIdAsync(user, cancellationToken);
		}

		public async Task DisposeGetByIdAsync(
			GetCurrentUserByIdApiRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeGetByIdAsync(user, cancellationToken);
		}

		public async Task DisposeGetByIdAsync(
			GetCurrentUserDetailsByIdApiRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeGetByIdAsync(user, cancellationToken);
		}

		public async Task DisposeGetByIdAsync(
			GetUserByIdApiRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeGetByIdAsync(user, cancellationToken);
		}

		public async Task DisposeGetByIdAsync(
			GetUserDetailsByIdApiRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeGetByIdAsync(user, cancellationToken);
		}

		public async Task InitializeUpdateAsync(
			UpdateCurrentUserApiRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeUpdateAsync(user, request.Id, cancellationToken);
		}

		public async Task DisposeUpdateAsync(
			UpdateCurrentUserApiRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeUpdateAsync(user, cancellationToken);
		}
	}
}
