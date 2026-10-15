using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Abstractions;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.ValueObjects;

using Microsoft.Extensions.DependencyInjection;

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
			await serviceScope.GetEmailConfirmationTokenCommandRepository().AddAsync(emailConfirmationToken, cancellationToken);
		}

		public async Task AddRangeAsync(
			IEnumerable<EmailConfirmationToken> emailConfirmationTokens,
			CancellationToken cancellationToken)
		{
			await serviceScope.GetEmailConfirmationTokenCommandRepository().AddRangeAsync(emailConfirmationTokens, cancellationToken);
		}

		public async Task UpdateAsync(
			EmailConfirmationToken emailConfirmationToken,
			CancellationToken cancellationToken)
		{
			await serviceScope.GetEmailConfirmationTokenCommandRepository().UpdateAsync(emailConfirmationToken, cancellationToken);
		}

		public async Task DeleteAsync(
			EmailConfirmationToken emailConfirmationToken,
			CancellationToken cancellationToken)
		{
			await serviceScope.GetEmailConfirmationTokenCommandRepository().DeleteAsync(emailConfirmationToken, cancellationToken);
		}

		public async Task DeleteRangeAsync(
			IEnumerable<EmailConfirmationToken> emailConfirmationTokens,
			CancellationToken cancellationToken)
		{
			await serviceScope.GetEmailConfirmationTokenCommandRepository().DeleteRangeAsync(emailConfirmationTokens, cancellationToken);
		}
	}
}
