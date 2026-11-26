using InstaConnect.Common.Domain.Features.ValueObjects.Models;
using InstaConnect.Identity.Domain.Features.Users.Abstractions;
using InstaConnect.Identity.Domain.Features.Users.Models.Responses;
using InstaConnect.Identity.Infrastructure.Features.Users.Abstractions;

namespace InstaConnect.Identity.Tests.Features.Users.Utilities;

public static class UserSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public IUserQueryRepository GetQueryRepository()
		{
			return serviceProvider.GetRequiredService<IUserQueryRepository>();
		}

		public IUserCommandRepository GetCommandRepository()
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

		public IUserCommandRepository GetCommandRepository()
		{
			return serviceScope.ServiceProvider.GetCommandRepository();
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
			CancellationToken cancellationToken)
		{
			var repository = serviceScope.GetCommandRepository();

			await repository.AddAsync(user, cancellationToken);
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
			CancellationToken cancellationToken)
		{
			var repository = serviceScope.GetCommandRepository();

			await repository.AddRangeAsync(users, cancellationToken);
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

		public async Task<UserResponse?> GetUserCacheByIdAsync(
			string id,
			string currentUserId,
			CancellationToken cancellationToken)
		{
			var cacheHandler = serviceScope.GetCacheHandler();

			return await cacheHandler.GetByIdAsync(new(id), new(currentUserId), cancellationToken);
		}

		public async Task<UserResponse?> GetUserCacheByIdAsync(
			UserId id,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			var cacheHandler = serviceScope.GetCacheHandler();

			return await cacheHandler.GetByIdAsync(id, currentUserId, cancellationToken);
		}

		public async Task SetupAddUserAsync(
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddAsync(user, cancellationToken);
		}

		public async Task SetupDeleteUserAsync(
			User user,
			ICollection<UserClaim> userClaims,
			ICollection<RefreshToken> refreshTokens,
			ICollection<ForgotPasswordToken> forgotPasswordTokens,
			ICollection<EmailConfirmationToken> emailConfirmationTokens,
			string currentUserId,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddAsync(user, cancellationToken);
			await serviceScope.AddRangeAsync(userClaims, cancellationToken);
			await serviceScope.AddRangeAsync(refreshTokens, cancellationToken);
			await serviceScope.AddRangeAsync(forgotPasswordTokens, cancellationToken);
			await serviceScope.AddRangeAsync(emailConfirmationTokens, cancellationToken);
			await serviceScope.AddUserCacheAsync(user, currentUserId, cancellationToken);
		}

		public async Task SetupDeleteUserAsync(
			User user,
			ICollection<UserClaim> userClaims,
			ICollection<RefreshToken> refreshTokens,
			ICollection<ForgotPasswordToken> forgotPasswordTokens,
			ICollection<EmailConfirmationToken> emailConfirmationTokens,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupDeleteUserAsync(user, userClaims, refreshTokens, forgotPasswordTokens, emailConfirmationTokens, currentUserId.Id, cancellationToken);
		}

		public async Task SetupGetAllUsersAsync(
			ICollection<User> users,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddRangeAsync(users, cancellationToken);
		}

		public async Task SetupGetUserByIdAsync(
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddAsync(user, cancellationToken);
		}


		public async Task SetupUpdateUserAsync(
			User user,
			ICollection<EmailConfirmationToken> emailConfirmationTokens,
			string currentUserId,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddAsync(user, cancellationToken);
			await serviceScope.AddRangeAsync(emailConfirmationTokens, cancellationToken);
			await serviceScope.AddUserCacheAsync(user, currentUserId, cancellationToken);
		}

		public async Task SetupUpdateUserAsync(
			User user,
			ICollection<EmailConfirmationToken> emailConfirmationTokens,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupUpdateUserAsync(user, emailConfirmationTokens, currentUserId.Id, cancellationToken);
		}

		public async Task AddUserCacheAsync(
			User user,
			string currentUserId,
			CancellationToken cancellationToken)
		{
			var cacheHandler = serviceScope.GetCacheHandler();

			await cacheHandler.AddAsync(user.ToFullResponse(), new(currentUserId), cancellationToken);
		}

		public async Task AddUserCacheAsync(
			User user,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddUserCacheAsync(user, currentUserId.Id, cancellationToken);
		}
	}
}
