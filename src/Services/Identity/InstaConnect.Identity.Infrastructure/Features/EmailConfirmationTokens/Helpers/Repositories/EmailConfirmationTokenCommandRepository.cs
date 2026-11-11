using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Abstractions;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Requests;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.ValueObjects;

namespace InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Helpers.Repositories;

internal class EmailConfirmationTokenCommandRepository : IEmailConfirmationTokenCommandRepository
{
	private readonly IEmailConfirmationTokenCollection _collection;
	private readonly IEmailConfirmationTokenCacheHandler _cacheHandler;
	private readonly IEmailConfirmationTokenIncludeBuilderFactory _includeBuilderFactory;

	public EmailConfirmationTokenCommandRepository(
		IEmailConfirmationTokenCollection collection,
		IEmailConfirmationTokenCacheHandler cacheHandler,
		IEmailConfirmationTokenIncludeBuilderFactory includeBuilderFactory)
	{
		_collection = collection;
		_cacheHandler = cacheHandler;
		_includeBuilderFactory = includeBuilderFactory;
	}

	public async Task<EmailConfirmationToken?> GetByIdAsync(
		EmailConfirmationTokenId id,
		EmailConfirmationTokenInclude include,
		CancellationToken cancellationToken)
	{
		return await _collection
			.AggregateFluent()
			.Match(id)
			.ApplyIncludes(include)
			.FirstOrDefaultAsync(cancellationToken);
	}

	public async Task<EmailConfirmationToken?> GetByIdAsync(
		EmailConfirmationTokenId id,
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

	public async Task<ICollection<EmailConfirmationToken>> GetByIdRangeAsync(
		IEnumerable<EmailConfirmationTokenId> ids,
		CancellationToken cancellationToken)
	{
		return await _collection
			.AggregateFluent()
			.Match(ids)
			.ToListAsync(cancellationToken);
	}

	public async Task<bool> ExistsByIdAsync(
		EmailConfirmationTokenId id,
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

	public async Task AddAsync(EmailConfirmationToken entity, CancellationToken cancellationToken)
	{
		await _collection.AddAsync(entity, cancellationToken);
	}

	public async Task AddRangeAsync(IEnumerable<EmailConfirmationToken> entities, CancellationToken cancellationToken)
	{
		await _collection.AddRangeAsync(entities, cancellationToken);
	}

	public async Task UpdateAsync(EmailConfirmationToken entity, CancellationToken cancellationToken)
	{
		await _collection.UpdateAsync(entity, cancellationToken);
	}

	public async Task DeleteAsync(EmailConfirmationToken entity, CancellationToken cancellationToken)
	{
		await _collection.DeleteAsync(entity, cancellationToken);
	}

	public async Task DeleteRangeAsync(IEnumerable<EmailConfirmationToken> entities, CancellationToken cancellationToken)
	{
		await _collection.DeleteRangeAsync(entities, cancellationToken);
	}
}
