using InstaConnect.Common.Infrastructure.Features.Caches.Abstractions;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.ValueObjects;
using InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Utilities;

namespace InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Helpers.Caches;

internal class ForgotPasswordTokenCacheHandler : IForgotPasswordTokenCacheHandler
{
	private readonly ICacheHandler _cacheHandler;

	public ForgotPasswordTokenCacheHandler(ICacheHandler cacheHandler)
	{
		_cacheHandler = cacheHandler;
	}

	public async Task DeleteAsync(ForgotPasswordTokenId id, CancellationToken cancellationToken)
	{
		await _cacheHandler.RemoveByTagAsync(ForgotPasswordTokenCacheUtilities.GetTag(id), cancellationToken);
	}

	public async Task DeleteRangeAsync(IEnumerable<ForgotPasswordTokenId> ids, CancellationToken cancellationToken)
	{
		await _cacheHandler.RemoveByTagRangeAsync(ForgotPasswordTokenCacheUtilities.GetTagRange(ids), cancellationToken);
	}
}
