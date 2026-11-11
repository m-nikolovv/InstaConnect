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

	public async Task<EmailConfirmationToken?> GetByIdAsync(EmailConfirmationTokenId id)
	{
		return await _cacheHandler.GetAsync<EmailConfirmationToken>(EmailConfirmationTokenCacheUtilities.GetByIdKey(id));
	}

	public async Task AddAsync(EmailConfirmationToken entity)
	{
		await _cacheHandler.SetAsync(
			EmailConfirmationTokenCacheUtilities.GetByIdKey(entity.Id),
			entity,
			_cacheOptions.Expirations[EmailConfirmationTokenCacheUtilities.GetByIdKeyPrefix],
			[EmailConfirmationTokenCacheUtilities.GetTag(entity.Id),
			 UserCacheUtilities.GetTag(entity.Id.Id)]);
	}

	public async Task AddRangeAsync(IEnumerable<EmailConfirmationToken> entities)
	{
		foreach (var entity in entities)
		{
			await AddAsync(entity);
		}
	}

	public async Task<bool?> ExistsByIdAsync(EmailConfirmationTokenId id)
	{
		return await _cacheHandler.GetAsync<bool?>(EmailConfirmationTokenCacheUtilities.ExistsByIdKey(id));
	}

	public async Task AddExistsByIdAsync(EmailConfirmationTokenId id, bool exists)
	{
		await _cacheHandler.SetAsync<bool?>(
			EmailConfirmationTokenCacheUtilities.ExistsByIdKey(id),
			exists,
			_cacheOptions.Expirations[EmailConfirmationTokenCacheUtilities.ExistsByIdKeyPrefix],
			[EmailConfirmationTokenCacheUtilities.GetTag(id),
			 UserCacheUtilities.GetTag(id.Id)]);
	}

	public async Task DeleteAsync(EmailConfirmationTokenId id)
	{
		await _cacheHandler.RemoveByTagAsync(EmailConfirmationTokenCacheUtilities.GetTag(id));
	}

	public async Task DeleteRangeAsync(IEnumerable<EmailConfirmationTokenId> ids)
	{
		await _cacheHandler.RemoveByTagRangeAsync(EmailConfirmationTokenCacheUtilities.GetTagRange(ids));
	}
}
