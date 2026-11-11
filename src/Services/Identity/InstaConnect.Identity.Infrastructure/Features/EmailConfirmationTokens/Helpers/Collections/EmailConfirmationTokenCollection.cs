using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.ValueObjects;
using InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Extensions;

namespace InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Helpers.Collections;

internal class EmailConfirmationTokenCollection : MongoDbCollection<EmailConfirmationToken, EmailConfirmationTokenId>, IEmailConfirmationTokenCollection
{
	private readonly IEmailConfirmationTokenCacheHandler _cacheHandler;
	private readonly IEmailConfirmationTokenFluentFactory _fluentFactory;

	public EmailConfirmationTokenCollection(
		ISessionHandler sessionHandler,
		IEmailConfirmationTokenCacheHandler cacheHandler,
		IEmailConfirmationTokenFluentFactory fluentFactory,
		IMongoCollection<EmailConfirmationToken> collection) : base(sessionHandler, collection)
	{
		_cacheHandler = cacheHandler;
		_fluentFactory = fluentFactory;
	}

	public IEmailConfirmationTokenFluent AggregateFluent()
	{
		var fluent = AggregateWithIgnoreCaseCollation();

		return _fluentFactory.Create(fluent);
	}

	public async Task AddAsync(
		EmailConfirmationToken entity,
		CancellationToken cancellationToken)
	{
		await InsertAsync(entity, cancellationToken);
		await _cacheHandler.DeleteAsync(entity.Id);
	}

	public async Task AddByParentAsync(
		FilterDefinition<EmailConfirmationToken> filter,
		CancellationToken cancellationToken)
	{
		await UpdateByParentAsync(filter, cancellationToken);
	}

	public async Task AddRangeAsync(
		IEnumerable<EmailConfirmationToken> entities,
		CancellationToken cancellationToken)
	{
		await InsertRangeAsync(entities, cancellationToken);
		await _cacheHandler.DeleteRangeAsync(entities.Select(p => p.Id));
	}

	public async Task UpdateAsync(
		EmailConfirmationToken entity,
		CancellationToken cancellationToken)
	{
		await ReplaceAsync(entity.Id.GetFilter(), entity, cancellationToken);
		await _cacheHandler.DeleteAsync(entity.Id);
	}

	public async Task UpdateByParentAsync(
		FilterDefinition<EmailConfirmationToken> filter,
		CancellationToken cancellationToken)
	{
		var tokenIds = await GetIdsAsync(filter, cancellationToken);

		await _cacheHandler.DeleteRangeAsync(tokenIds);
	}

	public async Task DeleteAsync(
		EmailConfirmationToken entity,
		CancellationToken cancellationToken)
	{
		await RemoveAsync(entity.Id.GetFilter(), cancellationToken);
		await _cacheHandler.DeleteAsync(entity.Id);
	}

	public async Task DeleteByParentAsync(
		FilterDefinition<EmailConfirmationToken> filter,
		CancellationToken cancellationToken)
	{
		var tokenIds = await GetIdsAsync(filter, cancellationToken);

		await RemoveRangeAsync(filter, cancellationToken);
		await _cacheHandler.DeleteRangeAsync(tokenIds);
	}

	public async Task DeleteRangeAsync(
		IEnumerable<EmailConfirmationToken> entities,
		CancellationToken cancellationToken)
	{
		await RemoveRangeAsync(entities.Select(p => p.Id).GetFilter(), cancellationToken);
		await _cacheHandler.DeleteRangeAsync(entities.Select(p => p.Id));
	}
}
