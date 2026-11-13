using InstaConnect.Common.Infrastructure.Features.Caches.Abstractions;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.ValueObjects;
using InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Models.Options;
using InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Utilities;
using InstaConnect.Identity.Infrastructure.Features.Users.Utilities;

namespace InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Helpers.Caches;

internal class ForgotPasswordTokenCacheHandler : IForgotPasswordTokenCacheHandler
{
	private readonly ICacheHandler _cacheHandler;
	private readonly ForgotPasswordTokenCacheOptions _cacheOptions;

	public ForgotPasswordTokenCacheHandler(ICacheHandler cacheHandler, ForgotPasswordTokenCacheOptions cacheOptions)
	{
		_cacheHandler = cacheHandler;
		_cacheOptions = cacheOptions;
	}

	public async Task<ForgotPasswordToken?> GetByIdAsync(ForgotPasswordTokenId id, CancellationToken cancellationToken)
	{
		return await _cacheHandler.GetAsync<ForgotPasswordToken>(ForgotPasswordTokenCacheUtilities.GetByIdKey(id), cancellationToken);
	}

	public async Task AddAsync(ForgotPasswordToken entity, CancellationToken cancellationToken)
	{
		await _cacheHandler.SetAsync(
			ForgotPasswordTokenCacheUtilities.GetByIdKey(entity.Id),
			entity,
			_cacheOptions.Expirations[ForgotPasswordTokenCacheUtilities.GetByIdKeyPrefix],
			[ForgotPasswordTokenCacheUtilities.GetTag(entity.Id)],
			[UserCacheUtilities.GetTag(entity.Id.Id)],
			cancellationToken);
	}

	public async Task AddRangeAsync(IEnumerable<ForgotPasswordToken> entities, CancellationToken cancellationToken)
	{
		foreach (var entity in entities)
		{
			await AddAsync(entity, cancellationToken);
		}
	}

	public async Task<bool?> ExistsByIdAsync(ForgotPasswordTokenId id, CancellationToken cancellationToken)
	{
		return await _cacheHandler.GetAsync<bool?>(ForgotPasswordTokenCacheUtilities.ExistsByIdKey(id), cancellationToken);
	}

	public async Task AddExistsByIdAsync(ForgotPasswordTokenId id, bool exists, CancellationToken cancellationToken)
	{
		await _cacheHandler.SetAsync<bool?>(
			ForgotPasswordTokenCacheUtilities.ExistsByIdKey(id),
			exists,
			_cacheOptions.Expirations[ForgotPasswordTokenCacheUtilities.ExistsByIdKeyPrefix],
			[ForgotPasswordTokenCacheUtilities.GetTag(id)],
			[UserCacheUtilities.GetTag(id.Id)],
			cancellationToken);
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
