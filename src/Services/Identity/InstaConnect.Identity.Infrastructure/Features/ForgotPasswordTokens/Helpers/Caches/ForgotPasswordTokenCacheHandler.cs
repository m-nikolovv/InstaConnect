using InstaConnect.Common.Infrastructure.Features.Caches.Abstractions;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.ValueObjects;
using InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Models.Options;
using InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Utilities;

using Microsoft.Extensions.Options;

namespace InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Helpers.Caches;

internal class ForgotPasswordTokenCacheHandler : IForgotPasswordTokenCacheHandler
{
	private readonly ICacheHandler _cacheHandler;
	private readonly ForgotPasswordTokenCacheOptions _cacheOptions;

	public ForgotPasswordTokenCacheHandler(ICacheHandler cacheHandler, IOptions<ForgotPasswordTokenCacheOptions> cacheOptions)
	{
		_cacheHandler = cacheHandler;
		_cacheOptions = cacheOptions.Value;
	}

	public async Task<ForgotPasswordToken?> GetByIdAsync(ForgotPasswordTokenId id)
	{
		return await _cacheHandler.GetAsync<ForgotPasswordToken>(ForgotPasswordTokenCacheUtilities.GetByIdKey(id));
	}

	public async Task AddAsync(ForgotPasswordToken entity)
	{
		await _cacheHandler.SetAsync(
			ForgotPasswordTokenCacheUtilities.GetByIdKey(entity.Id),
			entity,
			_cacheOptions.Expirations[ForgotPasswordTokenCacheUtilities.GetByIdKeyPrefix],
			[ForgotPasswordTokenCacheUtilities.GetTag(entity.Id)]);
	}

	public async Task AddRangeAsync(IEnumerable<ForgotPasswordToken> entities)
	{
		foreach (var entity in entities)
		{
			await AddAsync(entity);
		}
	}

	public async Task<bool?> ExistsByIdAsync(ForgotPasswordTokenId id)
	{
		return await _cacheHandler.GetAsync<bool?>(ForgotPasswordTokenCacheUtilities.ExistsByIdKey(id));
	}

	public async Task AddExistsByIdAsync(ForgotPasswordTokenId id, bool exists)
	{
		await _cacheHandler.SetAsync<bool?>(
			ForgotPasswordTokenCacheUtilities.ExistsByIdKey(id),
			exists,
			_cacheOptions.Expirations[ForgotPasswordTokenCacheUtilities.ExistsByIdKeyPrefix],
			[ForgotPasswordTokenCacheUtilities.GetTag(id)]);
	}

	public async Task DeleteAsync(ForgotPasswordTokenId id)
	{
		await _cacheHandler.RemoveByTagAsync(ForgotPasswordTokenCacheUtilities.GetTag(id));
	}

	public async Task DeleteRangeAsync(IEnumerable<ForgotPasswordTokenId> ids)
	{
		await _cacheHandler.RemoveByTagRangeAsync(ForgotPasswordTokenCacheUtilities.GetTagRange(ids));
	}
}
