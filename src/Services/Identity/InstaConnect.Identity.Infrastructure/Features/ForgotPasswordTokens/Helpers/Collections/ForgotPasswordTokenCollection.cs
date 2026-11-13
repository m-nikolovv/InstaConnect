using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.ValueObjects;
using InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Extensions;

namespace InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Helpers.Collections;

internal class ForgotPasswordTokenCollection : IForgotPasswordTokenCollection
{
	private readonly IForgotPasswordTokenFluentFactory _fluentFactory;
	private readonly IMongoDbCollectionHandler<ForgotPasswordToken, ForgotPasswordTokenId> _collectionHandler;

	public ForgotPasswordTokenCollection(
		IForgotPasswordTokenFluentFactory fluentFactory,
		IMongoDbCollectionHandler<ForgotPasswordToken, ForgotPasswordTokenId> collectionHandler)
	{
		_fluentFactory = fluentFactory;
		_collectionHandler = collectionHandler;
	}

	public IForgotPasswordTokenFluent AggregateFluent()
	{
		var fluent = _collectionHandler.AggregateWithIgnoreCaseCollation();

		return _fluentFactory.Create(fluent);
	}

	public async Task AddAsync(
		ForgotPasswordToken entity,
		CancellationToken cancellationToken)
	{
		await _collectionHandler.InsertAsync(entity, cancellationToken);
	}

	public async Task AddRangeAsync(
		IEnumerable<ForgotPasswordToken> entities,
		CancellationToken cancellationToken)
	{
		await _collectionHandler.InsertRangeAsync(entities, cancellationToken);
	}

	public async Task UpdateAsync(
		ForgotPasswordToken entity,
		CancellationToken cancellationToken)
	{
		await _collectionHandler.ReplaceAsync(entity.Id.GetFilter(), entity, cancellationToken);
	}

	public async Task DeleteAsync(
		ForgotPasswordToken entity,
		CancellationToken cancellationToken)
	{
		await _collectionHandler.RemoveAsync(entity.Id.GetFilter(), cancellationToken);
	}

	public async Task DeleteByParentAsync(
		FilterDefinition<ForgotPasswordToken> filter,
		CancellationToken cancellationToken)
	{
		await _collectionHandler.RemoveRangeAsync(filter, cancellationToken);
	}

	public async Task DeleteRangeAsync(
		IEnumerable<ForgotPasswordToken> entities,
		CancellationToken cancellationToken)
	{
		await _collectionHandler.RemoveRangeAsync(entities.Select(p => p.Id).GetFilter(), cancellationToken);
	}
}
