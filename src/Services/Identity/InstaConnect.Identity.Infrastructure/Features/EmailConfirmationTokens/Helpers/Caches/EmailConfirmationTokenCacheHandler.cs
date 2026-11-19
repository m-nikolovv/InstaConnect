using InstaConnect.Common.Infrastructure.Features.Caches.Abstractions;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.ValueObjects;
using InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Utilities;

namespace InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Helpers.Caches;

internal class EmailConfirmationTokenCacheHandler : IEmailConfirmationTokenCacheHandler
{
	private readonly ICacheHandler _cacheHandler;

	public EmailConfirmationTokenCacheHandler(ICacheHandler cacheHandler)
	{
		_cacheHandler = cacheHandler;
	}

	public async Task DeleteAsync(EmailConfirmationTokenId id, CancellationToken cancellationToken)
	{
		await _cacheHandler.RemoveByTagAsync(EmailConfirmationTokenCacheUtilities.GetTag(id), cancellationToken);
	}

	public async Task DeleteRangeAsync(IEnumerable<EmailConfirmationTokenId> ids, CancellationToken cancellationToken)
	{
		await _cacheHandler.RemoveByTagRangeAsync(EmailConfirmationTokenCacheUtilities.GetTagRange(ids), cancellationToken);
	}
}
