using InstaConnect.Common.Domain.Features.ValueObjects.Models;
using InstaConnect.Identity.Domain.Features.Users.Abstractions;
using InstaConnect.Identity.Infrastructure.Features.Users.Abstractions;
using InstaConnect.Identity.Infrastructure.Features.Users.Helpers.Repositories;

namespace InstaConnect.Identity.Tests.Features.Users.Utilities;

public static class UserSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public IUserQueryRepository GetQueryRepository()
		{
			return new UserQueryRepository(serviceProvider.GetCollection());
		}

		public IUserQueryRepository GetCachedQueryRepository()
		{
			return serviceProvider.GetRequiredService<IUserQueryRepository>();
		}

		public IUserCommandRepository GetCommandRepository()
		{
			return new UserCommandRepository(
				serviceProvider.GetCollection(),
				serviceProvider.GetIncludeBuilderFactory());
		}

		public IUserCommandRepository GetCachedCommandRepository()
		{
			return serviceProvider.GetRequiredService<IUserCommandRepository>();
		}

		public IUserIncludeBuilderFactory GetIncludeBuilderFactory()
		{
			return serviceProvider.GetRequiredService<IUserIncludeBuilderFactory>();
		}

		public IUserCollection GetCollection()
		{
			return serviceProvider.GetRequiredService<IUserCollection>();
		}

		public IUserCacheHandler GetCacheHandler()
		{
			return serviceProvider.GetRequiredService<IUserCacheHandler>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public IUserQueryRepository GetQueryRepository()
		{
			return serviceScope.ServiceProvider.GetQueryRepository();
		}

		public IUserQueryRepository GetCachedQueryRepository()
		{
			return serviceScope.ServiceProvider.GetCachedQueryRepository();
		}

		public IUserCommandRepository GetCommandRepository()
		{
			return serviceScope.ServiceProvider.GetCommandRepository();
		}

		public IUserCommandRepository GetCachedCommandRepository()
		{
			return serviceScope.ServiceProvider.GetCachedCommandRepository();
		}

		public IUserIncludeBuilderFactory GetIncludeBuilderFactory()
		{
			return serviceScope.ServiceProvider.GetIncludeBuilderFactory();
		}

		public IUserCacheHandler GetCacheHandler()
		{
			return serviceScope.ServiceProvider.GetCacheHandler();
		}

		public async Task<User?> GetByIdAsync(
			UserId id,
			CancellationToken cancellationToken)
		{
			var include = serviceScope.GetIncludeBuilderFactory().Create().WithUserClaims().WithRefreshTokens().WithForgotPasswordTokens().WithEmailConfirmationTokens().Build();

			return (await serviceScope.GetCommandRepository().GetByIdAsync(id, include, cancellationToken)).SetUserClaims().SetRefreshTokens().SetForgotPasswordTokens().SetEmailConfirmationTokens();
		}

		public async Task<User?> GetByNameAsync(
			Name name,
			CancellationToken cancellationToken)
		{
			var include = serviceScope.GetIncludeBuilderFactory().Create().WithUserClaims().WithRefreshTokens().WithForgotPasswordTokens().WithEmailConfirmationTokens().Build();

			return (await serviceScope.GetCommandRepository().GetByNameAsync(name, include, cancellationToken)).SetUserClaims().SetRefreshTokens().SetForgotPasswordTokens().SetEmailConfirmationTokens();
		}

		public async Task<User?> GetByEmailAsync(
			Email email,
			CancellationToken cancellationToken)
		{
			var include = serviceScope.GetIncludeBuilderFactory().Create().WithUserClaims().WithRefreshTokens().WithForgotPasswordTokens().WithEmailConfirmationTokens().Build();

			return (await serviceScope.GetCommandRepository().GetByEmailAsync(email, include, cancellationToken)).SetUserClaims().SetRefreshTokens().SetForgotPasswordTokens().SetEmailConfirmationTokens();
		}

		public async Task AddAsync(
			User user,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			var cacheHandler = serviceScope.GetCacheHandler();

			await cacheHandler.AddAsync(user.ToFullResponse(), currentUserId, cancellationToken);
		}

		public async Task UpdateAsync(
			User user,
			CancellationToken cancellationToken)
		{
			var cacheHandler = serviceScope.GetCacheHandler();
			var repository = serviceScope.GetCommandRepository();

			await repository.UpdateAsync(user, cancellationToken);
			await cacheHandler.DeleteAsync(user.Id, cancellationToken);
		}

		public async Task AddRangeAsync(
			ICollection<User> users,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			var cacheHandler = serviceScope.GetCacheHandler();

			await cacheHandler.AddRangeAsync(users.ToFullResponse(), currentUserId, cancellationToken);
		}

		public async Task DeleteAsync(
			User user,
			CancellationToken cancellationToken)
		{
			var cacheHandler = serviceScope.GetCacheHandler();
			var repository = serviceScope.GetCommandRepository();

			await repository.DeleteAsync(user, cancellationToken);
			await cacheHandler.DeleteAsync(user.Id, cancellationToken);
		}
	}
}
