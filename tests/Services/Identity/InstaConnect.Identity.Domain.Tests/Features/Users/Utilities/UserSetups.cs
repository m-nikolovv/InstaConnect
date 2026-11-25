using InstaConnect.Identity.Infrastructure.Features.Users.Abstractions;

namespace InstaConnect.Identity.Domain.Tests.Features.Users.Utilities;

public static class UserSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public IUserCommandService GetCommandService()
		{
			return serviceProvider.GetRequiredService<IUserCommandService>();
		}

		public IUserQueryService GetQueryService()
		{
			return serviceProvider.GetRequiredService<IUserQueryService>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public IUserCommandService GetCommandService()
		{
			return serviceScope.ServiceProvider.GetCommandService();
		}

		public IUserQueryService GetQueryService()
		{
			return serviceScope.ServiceProvider.GetQueryService();
		}
	}

	extension(IUserCacheHandler cacheHandler)
	{
		public async Task<UserResponse?> GetByIdAsync(
			UpdateUserCommand command,
			CancellationToken cancellationToken)
		{
			return await cacheHandler.GetByIdAsync(command.Id, command.Id, cancellationToken);
		}

		public async Task<UserResponse?> GetByIdAsync(
			DeleteUserCommand command,
			CancellationToken cancellationToken)
		{
			return await cacheHandler.GetByIdAsync(command.Id, command.Id, cancellationToken);
		}

		public async Task<UserResponse?> GetByIdAsync(
			GetUserByIdQuery query,
			CancellationToken cancellationToken)
		{
			return await cacheHandler.GetByIdAsync(query.Id, query.Current.Id, cancellationToken);
		}
	}
}
