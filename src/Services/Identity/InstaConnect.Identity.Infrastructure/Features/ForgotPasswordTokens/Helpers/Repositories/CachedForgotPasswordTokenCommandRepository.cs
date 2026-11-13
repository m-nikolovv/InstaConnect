using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Abstractions;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Requests;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.ValueObjects;

namespace InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Helpers.Repositories;

internal class CachedForgotPasswordTokenCommandRepository : IForgotPasswordTokenCommandRepository
{
	private readonly IForgotPasswordTokenCacheHandler _cacheHandler;
	private readonly IForgotPasswordTokenCommandRepository _repository;

	public CachedForgotPasswordTokenCommandRepository(
		IForgotPasswordTokenCacheHandler cacheHandler,
		IForgotPasswordTokenCommandRepository repository)
	{
		_repository = repository;
		_cacheHandler = cacheHandler;
	}

	public async Task<ForgotPasswordToken?> GetByIdAsync(
		ForgotPasswordTokenId id,
		ForgotPasswordTokenInclude include,
		CancellationToken cancellationToken)
	{
		return await _repository.GetByIdAsync(id, include, cancellationToken);
	}

	public async Task<ForgotPasswordToken?> GetByIdAsync(
		ForgotPasswordTokenId id,
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

	public async Task<ICollection<ForgotPasswordToken>> GetByIdRangeAsync(
		IEnumerable<ForgotPasswordTokenId> ids,
		CancellationToken cancellationToken)
	{
		return await _repository.GetByIdRangeAsync(ids, cancellationToken);
	}

	public async Task<bool> ExistsByIdAsync(
		ForgotPasswordTokenId id,
		CancellationToken cancellationToken)
	{
		var cachedExists = await _cacheHandler.ExistsByIdAsync(id, cancellationToken);

		if (cachedExists != null)
		{
			return cachedExists.Value;
		}

		var exists = await _repository.ExistsByIdAsync(id, cancellationToken);

		await _cacheHandler.AddExistsByIdAsync(id, exists, cancellationToken);

		return exists;
	}

	public async Task AddAsync(ForgotPasswordToken entity, CancellationToken cancellationToken)
	{
		await _repository.AddAsync(entity, cancellationToken);
		await _cacheHandler.DeleteAsync(entity.Id, cancellationToken);
	}

	public async Task AddRangeAsync(IEnumerable<ForgotPasswordToken> entities, CancellationToken cancellationToken)
	{
		await _repository.AddRangeAsync(entities, cancellationToken);
		await _cacheHandler.DeleteRangeAsync(entities.Select(p => p.Id), cancellationToken);
	}

	public async Task UpdateAsync(ForgotPasswordToken entity, CancellationToken cancellationToken)
	{
		await _repository.UpdateAsync(entity, cancellationToken);
		await _cacheHandler.DeleteAsync(entity.Id, cancellationToken);
	}

	public async Task DeleteAsync(ForgotPasswordToken entity, CancellationToken cancellationToken)
	{
		await _repository.DeleteAsync(entity, cancellationToken);
		await _cacheHandler.DeleteAsync(entity.Id, cancellationToken);
	}

	public async Task DeleteRangeAsync(IEnumerable<ForgotPasswordToken> entities, CancellationToken cancellationToken)
	{
		await _repository.DeleteRangeAsync(entities, cancellationToken);
		await _cacheHandler.DeleteRangeAsync(entities.Select(p => p.Id), cancellationToken);
	}
}
