using InstaConnect.Common.Infrastructure.Features.Caches.Abstractions;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.ValueObjects;
using InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Models.Options;
using InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Utilities;
using InstaConnect.Identity.Infrastructure.Features.Users.Utilities;

using Microsoft.Extensions.Options;

namespace InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Helpers.Caches;

internal class EmailConfirmationTokenCacheHandler : IEmailConfirmationTokenCacheHandler
{
	private readonly ICacheHandler _cacheHandler;
	private readonly EmailConfirmationTokenCacheOptions _cacheOptions;

	public EmailConfirmationTokenCacheHandler(ICacheHandler cacheHandler, IOptions<EmailConfirmationTokenCacheOptions> cacheOptions)
	{
		_cacheHandler = cacheHandler;
		_cacheOptions = cacheOptions.Value;
	}

	public async Task<EmailConfirmationToken?> GetByIdAsync(EmailConfirmationTokenId id, CancellationToken cancellationToken)
	{
		return await _cacheHandler.GetAsync<EmailConfirmationToken>(EmailConfirmationTokenCacheUtilities.GetByIdKey(id), cancellationToken);
	}

	public async Task AddAsync(EmailConfirmationToken entity, CancellationToken cancellationToken)
	{
		await _cacheHandler.SetAsync(
			EmailConfirmationTokenCacheUtilities.GetByIdKey(entity.Id),
			entity,
			_cacheOptions.Expirations[EmailConfirmationTokenCacheUtilities.GetByIdKeyPrefix],
			[EmailConfirmationTokenCacheUtilities.GetTag(entity.Id)],
			[UserCacheUtilities.GetTag(entity.Id.Id)],
			cancellationToken);
	}

	public async Task AddRangeAsync(IEnumerable<EmailConfirmationToken> entities, CancellationToken cancellationToken)
	{
		foreach (var entity in entities)
		{
			await AddAsync(entity, cancellationToken);
		}
	}

	public async Task<bool?> ExistsByIdAsync(EmailConfirmationTokenId id, CancellationToken cancellationToken)
	{
		return await _cacheHandler.GetAsync<bool?>(EmailConfirmationTokenCacheUtilities.ExistsByIdKey(id), cancellationToken);
	}

	public async Task AddExistsByIdAsync(EmailConfirmationTokenId id, bool exists, CancellationToken cancellationToken)
	{
		await _cacheHandler.SetAsync<bool?>(
			EmailConfirmationTokenCacheUtilities.ExistsByIdKey(id),
			exists,
			_cacheOptions.Expirations[EmailConfirmationTokenCacheUtilities.ExistsByIdKeyPrefix],
			[EmailConfirmationTokenCacheUtilities.GetTag(id)],
			[UserCacheUtilities.GetTag(id.Id)],
			cancellationToken);
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
