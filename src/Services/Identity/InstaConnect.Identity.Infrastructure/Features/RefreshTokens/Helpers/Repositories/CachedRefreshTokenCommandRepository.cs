using InstaConnect.Identity.Domain.Features.RefreshTokens.Abstractions;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Requests;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.ValueObjects;

namespace InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Helpers.Repositories;

internal class CachedRefreshTokenCommandRepository : IRefreshTokenCommandRepository
{
	private readonly IRefreshTokenCacheHandler _cacheHandler;
	private readonly IRefreshTokenCommandRepository _repository;

	public CachedRefreshTokenCommandRepository(
		IRefreshTokenCacheHandler cacheHandler,
		IRefreshTokenCommandRepository repository)
	{
		_repository = repository;
		_cacheHandler = cacheHandler;
	}

	public async Task<RefreshToken?> GetByIdAsync(
		RefreshTokenId id,
		RefreshTokenInclude include,
		CancellationToken cancellationToken)
	{
		return await _repository.GetByIdAsync(id, include, cancellationToken);
	}

	public async Task<RefreshToken?> GetByIdAsync(
		RefreshTokenId id,
		CancellationToken cancellationToken)
	{
		var cachedEntity = await _cacheHandler.GetByIdAsync(id, cancellationToken);

		if (cachedEntity != null)
		{
			return cachedEntity;
		}

		var entity = await _repository.GetByIdAsync(id, cancellationToken);

		if (entity != null)
		{
			await _cacheHandler.AddAsync(entity, cancellationToken);
		}

		return entity;
	}

	public async Task<ICollection<RefreshToken>> GetByIdRangeAsync(
		IEnumerable<RefreshTokenId> ids,
		CancellationToken cancellationToken)
	{
		return await _repository.GetByIdRangeAsync(ids, cancellationToken);
	}

	public async Task AddAsync(RefreshToken entity, CancellationToken cancellationToken)
	{
		await _repository.AddAsync(entity, cancellationToken);
		await _cacheHandler.DeleteAsync(entity.Id, cancellationToken);
	}

	public async Task AddRangeAsync(IEnumerable<RefreshToken> entities, CancellationToken cancellationToken)
	{
		await _repository.AddRangeAsync(entities, cancellationToken);
		await _cacheHandler.DeleteRangeAsync(entities.Select(p => p.Id), cancellationToken);
	}

	public async Task UpdateAsync(RefreshToken entity, CancellationToken cancellationToken)
	{
		await _repository.UpdateAsync(entity, cancellationToken);
		await _cacheHandler.DeleteAsync(entity.Id, cancellationToken);
	}

	public async Task DeleteAsync(RefreshToken entity, CancellationToken cancellationToken)
	{
		await _repository.DeleteAsync(entity, cancellationToken);
		await _cacheHandler.DeleteAsync(entity.Id, cancellationToken);
	}
}
