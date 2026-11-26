using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Abstractions;
using InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Abstractions;

namespace InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Utilities;

public static class EmailConfirmationTokenSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public IEmailConfirmationTokenCommandRepository GetEmailConfirmationTokenCommandRepository()
		{
			return serviceProvider.GetRequiredService<IEmailConfirmationTokenCommandRepository>();
		}

		public IEmailConfirmationTokenIncludeBuilderFactory GetEmailConfirmationTokenIncludeBuilderFactory()
		{
			return serviceProvider.GetRequiredService<IEmailConfirmationTokenIncludeBuilderFactory>();
		}

		public IEmailConfirmationTokenCollection GetEmailConfirmationTokenCollection()
		{
			return serviceProvider.GetRequiredService<IEmailConfirmationTokenCollection>();
		}

		public IEmailConfirmationTokenCacheHandler GetEmailConfirmationTokenCacheHandler()
		{
			return serviceProvider.GetRequiredService<IEmailConfirmationTokenCacheHandler>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public IEmailConfirmationTokenCommandRepository GetEmailConfirmationTokenCommandRepository()
		{
			return serviceScope.ServiceProvider.GetEmailConfirmationTokenCommandRepository();
		}

		public IEmailConfirmationTokenIncludeBuilderFactory GetEmailConfirmationTokenIncludeBuilderFactory()
		{
			return serviceScope.ServiceProvider.GetEmailConfirmationTokenIncludeBuilderFactory();
		}

		public IEmailConfirmationTokenCacheHandler GetEmailConfirmationTokenCacheHandler()
		{
			return serviceScope.ServiceProvider.GetEmailConfirmationTokenCacheHandler();
		}

		public async Task<EmailConfirmationToken?> GetByIdAsync(
			EmailConfirmationTokenId id,
			CancellationToken cancellationToken)
		{
			var include = serviceScope.GetEmailConfirmationTokenIncludeBuilderFactory().Create().WithUser().Build();

			return (await serviceScope.GetEmailConfirmationTokenCommandRepository().GetByIdAsync(id, include, cancellationToken)).SetUser();
		}

		public async Task<ICollection<EmailConfirmationToken>> GetByIdRangeAsync(
			IEnumerable<EmailConfirmationTokenId> ids,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetEmailConfirmationTokenCommandRepository().GetByIdRangeAsync(ids, cancellationToken);
		}

		public async Task AddAsync(
			EmailConfirmationToken emailConfirmationToken,
			CancellationToken cancellationToken)
		{
			var emailConfirmationTokenRepository = serviceScope.GetEmailConfirmationTokenCommandRepository();

			await emailConfirmationTokenRepository.AddAsync(emailConfirmationToken, cancellationToken);
		}

		public async Task AddRangeAsync(
			IEnumerable<EmailConfirmationToken> emailConfirmationTokens,
			CancellationToken cancellationToken)
		{
			var emailConfirmationTokenRepository = serviceScope.GetEmailConfirmationTokenCommandRepository();

			await emailConfirmationTokenRepository.AddRangeAsync(emailConfirmationTokens, cancellationToken);
		}

		public async Task UpdateAsync(
			EmailConfirmationToken emailConfirmationToken,
			CancellationToken cancellationToken)
		{
			var emailConfirmationTokenRepository = serviceScope.GetEmailConfirmationTokenCommandRepository();

			await emailConfirmationTokenRepository.UpdateAsync(emailConfirmationToken, cancellationToken);
		}

		public async Task DeleteAsync(
			EmailConfirmationToken emailConfirmationToken,
			CancellationToken cancellationToken)
		{
			var cacheHandler = serviceScope.GetEmailConfirmationTokenCacheHandler();
			var emailConfirmationTokenRepository = serviceScope.GetEmailConfirmationTokenCommandRepository();

			await emailConfirmationTokenRepository.DeleteAsync(emailConfirmationToken, cancellationToken);
			await cacheHandler.DeleteAsync(emailConfirmationToken.Id, cancellationToken);
		}

		public async Task DeleteRangeAsync(
			IEnumerable<EmailConfirmationToken> emailConfirmationTokens,
			CancellationToken cancellationToken)
		{
			var cacheHandler = serviceScope.GetEmailConfirmationTokenCacheHandler();
			var emailConfirmationTokenRepository = serviceScope.GetEmailConfirmationTokenCommandRepository();

			await emailConfirmationTokenRepository.DeleteRangeAsync(emailConfirmationTokens, cancellationToken);
			await cacheHandler.DeleteRangeAsync(emailConfirmationTokens.Select(p => p.Id), cancellationToken);
		}

		public async Task SetupAddEmailConfirmationTokenAsync(
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddAsync(user, cancellationToken);
		}

		public async Task SetupDeleteEmailConfirmationTokenAsync(
			User user,
			EmailConfirmationToken emailConfirmationToken,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddAsync(user, cancellationToken);
			await serviceScope.AddAsync(emailConfirmationToken, cancellationToken);
		}

		public async Task SetupGetAllEmailConfirmationTokensAsync(
			ICollection<User> users,
			ICollection<EmailConfirmationToken> emailConfirmationTokens,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddRangeAsync(users, cancellationToken);
			await serviceScope.AddRangeAsync(emailConfirmationTokens, cancellationToken);
		}

		public async Task SetupGetEmailConfirmationTokenByIdAsync(
			User user,
			EmailConfirmationToken emailConfirmationToken,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddAsync(user, cancellationToken);
			await serviceScope.AddAsync(emailConfirmationToken, cancellationToken);
		}

		public async Task SetupUpdateEmailConfirmationTokenAsync(
			User user,
			EmailConfirmationToken emailConfirmationToken,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddAsync(user, cancellationToken);
			await serviceScope.AddAsync(emailConfirmationToken, cancellationToken);
		}

		public async Task SetupVerifyEmailConfirmationTokenAsync(
			User user,
			ICollection<EmailConfirmationToken> emailConfirmationTokens,
			string currentUserId,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddAsync(user, cancellationToken);
			await serviceScope.AddRangeAsync(emailConfirmationTokens, cancellationToken);
			await serviceScope.AddUserCacheAsync(user, currentUserId, cancellationToken);
		}

		public async Task SetupVerifyEmailConfirmationTokenAsync(
			User user,
			ICollection<EmailConfirmationToken> emailConfirmationTokens,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupVerifyEmailConfirmationTokenAsync(user, emailConfirmationTokens, currentUserId.Id, cancellationToken);
		}
	}
}
