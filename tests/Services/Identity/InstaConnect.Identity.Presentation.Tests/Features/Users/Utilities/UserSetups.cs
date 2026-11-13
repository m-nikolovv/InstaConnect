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
	}
}
