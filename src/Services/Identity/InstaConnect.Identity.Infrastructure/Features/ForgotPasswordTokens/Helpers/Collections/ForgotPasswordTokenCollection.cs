using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.ValueObjects;
using InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Extensions;

namespace InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Helpers.Collections;

internal class ForgotPasswordTokenCollection : MongoDbCollection<ForgotPasswordToken, ForgotPasswordTokenId>, IForgotPasswordTokenCollection
{
	private readonly IForgotPasswordTokenCacheHandler _cacheHandler;
	private readonly IForgotPasswordTokenFluentFactory _fluentFactory;

	public ForgotPasswordTokenCollection(
		ISessionHandler sessionHandler,
		IForgotPasswordTokenCacheHandler cacheHandler,
		IForgotPasswordTokenFluentFactory fluentFactory,
		IMongoCollection<ForgotPasswordToken> collection) : base(sessionHandler, collection)
	{
		_cacheHandler = cacheHandler;
		_fluentFactory = fluentFactory;
	}

	public IForgotPasswordTokenFluent AggregateFluent()
	{
		var fluent = AggregateWithIgnoreCaseCollation();

		return _fluentFactory.Create(fluent);
	}

	public async Task AddAsync(
		ForgotPasswordToken entity,
		CancellationToken cancellationToken)
	{
		await InsertAsync(entity, cancellationToken);
		await _cacheHandler.DeleteAsync(entity.Id);
	}

	public async Task AddByParentAsync(
		FilterDefinition<ForgotPasswordToken> filter,
		CancellationToken cancellationToken)
	{
		await UpdateByParentAsync(filter, cancellationToken);
	}

	public async Task AddRangeAsync(
		IEnumerable<ForgotPasswordToken> entities,
		CancellationToken cancellationToken)
	{
		await InsertRangeAsync(entities, cancellationToken);
		await _cacheHandler.DeleteRangeAsync(entities.Select(p => p.Id));
	}

	public async Task UpdateAsync(
		ForgotPasswordToken entity,
		CancellationToken cancellationToken)
	{
		await ReplaceAsync(entity.Id.GetFilter(), entity, cancellationToken);
		await _cacheHandler.DeleteAsync(entity.Id);
	}

	public async Task UpdateByParentAsync(
		FilterDefinition<ForgotPasswordToken> filter,
		CancellationToken cancellationToken)
	{
		var tokenIds = await GetIdsAsync(filter, cancellationToken);

		await _cacheHandler.DeleteRangeAsync(tokenIds);
	}

	public async Task DeleteAsync(
		ForgotPasswordToken entity,
		CancellationToken cancellationToken)
	{
		await RemoveAsync(entity.Id.GetFilter(), cancellationToken);
		await _cacheHandler.DeleteAsync(entity.Id);
	}

	public async Task DeleteByParentAsync(
		FilterDefinition<ForgotPasswordToken> filter,
		CancellationToken cancellationToken)
	{
		var tokenIds = await GetIdsAsync(filter, cancellationToken);

		await RemoveRangeAsync(filter, cancellationToken);
		await _cacheHandler.DeleteRangeAsync(tokenIds);
	}

	public async Task DeleteRangeAsync(
		IEnumerable<ForgotPasswordToken> entities,
		CancellationToken cancellationToken)
	{
		await RemoveRangeAsync(entities.Select(p => p.Id).GetFilter(), cancellationToken);
		await _cacheHandler.DeleteRangeAsync(entities.Select(p => p.Id));
	}
}
