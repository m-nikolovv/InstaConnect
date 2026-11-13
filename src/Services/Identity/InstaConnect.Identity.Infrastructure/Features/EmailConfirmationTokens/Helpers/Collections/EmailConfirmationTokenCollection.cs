using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.ValueObjects;
using InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Extensions;

namespace InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Helpers.Collections;

internal class EmailConfirmationTokenCollection : IEmailConfirmationTokenCollection
{
	private readonly IEmailConfirmationTokenFluentFactory _fluentFactory;
	private readonly IMongoDbCollectionHandler<EmailConfirmationToken, EmailConfirmationTokenId> _collectionHandler;

	public EmailConfirmationTokenCollection(
		IEmailConfirmationTokenFluentFactory fluentFactory,
		IMongoDbCollectionHandler<EmailConfirmationToken, EmailConfirmationTokenId> collectionHandler)
	{
		_fluentFactory = fluentFactory;
		_collectionHandler = collectionHandler;
	}

	public IEmailConfirmationTokenFluent AggregateFluent()
	{
		var fluent = _collectionHandler.AggregateWithIgnoreCaseCollation();

		return _fluentFactory.Create(fluent);
	}

	public async Task AddAsync(
		EmailConfirmationToken entity,
		CancellationToken cancellationToken)
	{
		await _collectionHandler.InsertAsync(entity, cancellationToken);
	}

	public async Task AddRangeAsync(
		IEnumerable<EmailConfirmationToken> entities,
		CancellationToken cancellationToken)
	{
		await _collectionHandler.InsertRangeAsync(entities, cancellationToken);
	}

	public async Task UpdateAsync(
		EmailConfirmationToken entity,
		CancellationToken cancellationToken)
	{
		await _collectionHandler.ReplaceAsync(entity.Id.GetFilter(), entity, cancellationToken);
	}

	public async Task DeleteAsync(
		EmailConfirmationToken entity,
		CancellationToken cancellationToken)
	{
		await _collectionHandler.RemoveAsync(entity.Id.GetFilter(), cancellationToken);
	}

	public async Task DeleteByParentAsync(
		FilterDefinition<EmailConfirmationToken> filter,
		CancellationToken cancellationToken)
	{
		await _collectionHandler.RemoveRangeAsync(filter, cancellationToken);
	}

	public async Task DeleteRangeAsync(
		IEnumerable<EmailConfirmationToken> entities,
		CancellationToken cancellationToken)
	{
		await _collectionHandler.RemoveRangeAsync(entities.Select(p => p.Id).GetFilter(), cancellationToken);
	}
}
