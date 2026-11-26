using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Abstractions;
using InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Abstractions;

namespace InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Utilities;

public static class ForgotPasswordTokenSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public IForgotPasswordTokenCommandRepository GetForgotPasswordTokenCommandRepository()
		{
			return serviceProvider.GetRequiredService<IForgotPasswordTokenCommandRepository>();
		}

		public IForgotPasswordTokenIncludeBuilderFactory GetForgotPasswordTokenIncludeBuilderFactory()
		{
			return serviceProvider.GetRequiredService<IForgotPasswordTokenIncludeBuilderFactory>();
		}

		public IForgotPasswordTokenCollection GetForgotPasswordTokenCollection()
		{
			return serviceProvider.GetRequiredService<IForgotPasswordTokenCollection>();
		}

		public IForgotPasswordTokenCacheHandler GetForgotPasswordTokenCacheHandler()
		{
			return serviceProvider.GetRequiredService<IForgotPasswordTokenCacheHandler>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public IForgotPasswordTokenCommandRepository GetForgotPasswordTokenCommandRepository()
		{
			return serviceScope.ServiceProvider.GetForgotPasswordTokenCommandRepository();
		}

		public IForgotPasswordTokenIncludeBuilderFactory GetForgotPasswordTokenIncludeBuilderFactory()
		{
			return serviceScope.ServiceProvider.GetForgotPasswordTokenIncludeBuilderFactory();
		}

		public IForgotPasswordTokenCacheHandler GetForgotPasswordTokenCacheHandler()
		{
			return serviceScope.ServiceProvider.GetForgotPasswordTokenCacheHandler();
		}

		public async Task<ForgotPasswordToken?> GetByIdAsync(
			ForgotPasswordTokenId id,
			CancellationToken cancellationToken)
		{
			var include = serviceScope.GetForgotPasswordTokenIncludeBuilderFactory().Create().WithUser().Build();

			return (await serviceScope.GetForgotPasswordTokenCommandRepository().GetByIdAsync(id, include, cancellationToken)).SetUser();
		}

		public async Task<ICollection<ForgotPasswordToken>> GetByIdRangeAsync(
			IEnumerable<ForgotPasswordTokenId> ids,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetForgotPasswordTokenCommandRepository().GetByIdRangeAsync(ids, cancellationToken);
		}

		public async Task AddAsync(
			ForgotPasswordToken forgotPasswordToken,
			CancellationToken cancellationToken)
		{
			var forgotPasswordTokenRepository = serviceScope.GetForgotPasswordTokenCommandRepository();

			await forgotPasswordTokenRepository.AddAsync(forgotPasswordToken, cancellationToken);
		}

		public async Task AddRangeAsync(
			IEnumerable<ForgotPasswordToken> forgotPasswordTokens,
			CancellationToken cancellationToken)
		{
			var forgotPasswordTokenRepository = serviceScope.GetForgotPasswordTokenCommandRepository();

			await forgotPasswordTokenRepository.AddRangeAsync(forgotPasswordTokens, cancellationToken);
		}

		public async Task UpdateAsync(
			ForgotPasswordToken forgotPasswordToken,
			CancellationToken cancellationToken)
		{
			var forgotPasswordTokenRepository = serviceScope.GetForgotPasswordTokenCommandRepository();

			await forgotPasswordTokenRepository.UpdateAsync(forgotPasswordToken, cancellationToken);
		}

		public async Task DeleteAsync(
			ForgotPasswordToken forgotPasswordToken,
			CancellationToken cancellationToken)
		{
			var cacheHandler = serviceScope.GetForgotPasswordTokenCacheHandler();
			var forgotPasswordTokenRepository = serviceScope.GetForgotPasswordTokenCommandRepository();

			await forgotPasswordTokenRepository.DeleteAsync(forgotPasswordToken, cancellationToken);
			await cacheHandler.DeleteAsync(forgotPasswordToken.Id, cancellationToken);
		}

		public async Task DeleteRangeAsync(
			IEnumerable<ForgotPasswordToken> forgotPasswordTokens,
			CancellationToken cancellationToken)
		{
			var cacheHandler = serviceScope.GetForgotPasswordTokenCacheHandler();
			var forgotPasswordTokenRepository = serviceScope.GetForgotPasswordTokenCommandRepository();

			await forgotPasswordTokenRepository.DeleteRangeAsync(forgotPasswordTokens, cancellationToken);
			await cacheHandler.DeleteRangeAsync(forgotPasswordTokens.Select(p => p.Id), cancellationToken);
		}

		public async Task SetupAddForgotPasswordTokenAsync(
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddAsync(user, cancellationToken);
		}

		public async Task SetupDeleteForgotPasswordTokenAsync(
			User user,
			ForgotPasswordToken forgotPasswordToken,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddAsync(user, cancellationToken);
			await serviceScope.AddAsync(forgotPasswordToken, cancellationToken);
		}

		public async Task SetupGetAllForgotPasswordTokensAsync(
			ICollection<User> users,
			ICollection<ForgotPasswordToken> forgotPasswordTokens,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddRangeAsync(users, cancellationToken);
			await serviceScope.AddRangeAsync(forgotPasswordTokens, cancellationToken);
		}

		public async Task SetupGetForgotPasswordTokenByIdAsync(
			User user,
			ForgotPasswordToken forgotPasswordToken,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddAsync(user, cancellationToken);
			await serviceScope.AddAsync(forgotPasswordToken, cancellationToken);
		}

		public async Task SetupUpdateForgotPasswordTokenAsync(
			User user,
			ForgotPasswordToken forgotPasswordToken,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddAsync(user, cancellationToken);
			await serviceScope.AddAsync(forgotPasswordToken, cancellationToken);
		}

		public async Task SetupVerifyForgotPasswordTokenAsync(
			User user,
			ICollection<ForgotPasswordToken> forgotPasswordTokens,
			string currentUserId,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddAsync(user, cancellationToken);
			await serviceScope.AddRangeAsync(forgotPasswordTokens, cancellationToken);
			await serviceScope.AddUserCacheAsync(user, currentUserId, cancellationToken);
		}

		public async Task SetupVerifyForgotPasswordTokenAsync(
			User user,
			ICollection<ForgotPasswordToken> forgotPasswordTokens,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupVerifyForgotPasswordTokenAsync(user, forgotPasswordTokens, currentUserId.Id, cancellationToken);
		}
	}
}
