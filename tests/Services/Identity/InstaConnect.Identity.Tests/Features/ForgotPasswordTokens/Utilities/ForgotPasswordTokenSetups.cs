using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Abstractions;
using InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Abstractions;
using InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Helpers.Repositories;

namespace InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Utilities;

public static class ForgotPasswordTokenSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public IForgotPasswordTokenCommandRepository GetForgotPasswordTokenCommandRepository()
		{
			return new ForgotPasswordTokenCommandRepository(
				serviceProvider.GetForgotPasswordTokenCollection(),
				serviceProvider.GetForgotPasswordTokenIncludeBuilderFactory());
		}

		public IForgotPasswordTokenCommandRepository GetCachedForgotPasswordTokenCommandRepository()
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

		public IForgotPasswordTokenCommandRepository GetCachedForgotPasswordTokenCommandRepository()
		{
			return serviceScope.ServiceProvider.GetCachedForgotPasswordTokenCommandRepository();
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
	}
}
