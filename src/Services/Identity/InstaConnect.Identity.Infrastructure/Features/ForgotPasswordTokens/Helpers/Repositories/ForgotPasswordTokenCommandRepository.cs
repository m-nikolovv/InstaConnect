using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Abstractions;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Requests;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.ValueObjects;

namespace InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Helpers.Repositories;

internal class ForgotPasswordTokenCommandRepository : IForgotPasswordTokenCommandRepository
{
	private readonly IForgotPasswordTokenCollection _collection;
	private readonly IForgotPasswordTokenCacheHandler _cacheHandler;
	private readonly IForgotPasswordTokenIncludeBuilderFactory _includeBuilderFactory;

	public ForgotPasswordTokenCommandRepository(
		IForgotPasswordTokenCollection collection,
		IForgotPasswordTokenCacheHandler cacheHandler,
		IForgotPasswordTokenIncludeBuilderFactory includeBuilderFactory)
	{
		_collection = collection;
		_cacheHandler = cacheHandler;
		_includeBuilderFactory = includeBuilderFactory;
	}

	public async Task<ForgotPasswordToken?> GetByIdAsync(
		ForgotPasswordTokenId id,
		ForgotPasswordTokenInclude include,
		CancellationToken cancellationToken)
	{
		return await _collection
			.AggregateFluent()
			.Match(id)
			.ApplyIncludes(include)
			.FirstOrDefaultAsync(cancellationToken);
	}

	public async Task<ForgotPasswordToken?> GetByIdAsync(
		ForgotPasswordTokenId id,
		CancellationToken cancellationToken)
	{
		var cachedEntity = await _cacheHandler.GetByIdAsync(id);

		if (cachedEntity != null)
		{
			return cachedEntity;
		}

		var include = _includeBuilderFactory.Create().Build();

		var entity = await GetByIdAsync(id, include, cancellationToken);

		if (entity != null)
		{
			await _cacheHandler.AddAsync(entity);
		}

		return entity;
	}

	public async Task<ICollection<ForgotPasswordToken>> GetByIdRangeAsync(
		IEnumerable<ForgotPasswordTokenId> ids,
		CancellationToken cancellationToken)
	{
		return await _collection
			.AggregateFluent()
			.Match(ids)
			.ToListAsync(cancellationToken);
	}

	public async Task<bool> ExistsByIdAsync(
		ForgotPasswordTokenId id,
		CancellationToken cancellationToken)
	{
		var cachedExists = await _cacheHandler.ExistsByIdAsync(id);

		if (cachedExists != null)
		{
			return cachedExists.Value;
		}

		var exists = await _collection
			.AggregateFluent()
			.Match(id)
			.AnyAsync(cancellationToken);

		await _cacheHandler.AddExistsByIdAsync(id, exists);

		return exists;
	}

	public async Task AddAsync(ForgotPasswordToken entity, CancellationToken cancellationToken)
	{
		await _collection.AddAsync(entity, cancellationToken);
	}

	public async Task AddRangeAsync(IEnumerable<ForgotPasswordToken> entities, CancellationToken cancellationToken)
	{
		await _collection.AddRangeAsync(entities, cancellationToken);
	}

	public async Task UpdateAsync(ForgotPasswordToken entity, CancellationToken cancellationToken)
	{
		await _collection.UpdateAsync(entity, cancellationToken);
	}

	public async Task DeleteAsync(ForgotPasswordToken entity, CancellationToken cancellationToken)
	{
		await _collection.DeleteAsync(entity, cancellationToken);
	}

	public async Task DeleteRangeAsync(IEnumerable<ForgotPasswordToken> entities, CancellationToken cancellationToken)
	{
		await _collection.DeleteRangeAsync(entities, cancellationToken);
	}
}
