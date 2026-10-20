using InstaConnect.Common.Infrastructure.Features.Databases.Extensions;

namespace InstaConnect.Common.Infrastructure.Features.Databases.Helpers;

public abstract class MongoDbCollection<TEntity> : IMongoDbCollection<TEntity> where TEntity : IEntity
{
	private readonly ISessionHandler _sessionHandler;
	private readonly IMongoCollection<TEntity> _mongoCollection;

	protected MongoDbCollection(
		ISessionHandler sessionHandler,
		IMongoCollection<TEntity> mongoCollection)
	{
		_sessionHandler = sessionHandler;
		_mongoCollection = mongoCollection;
	}

	protected IAggregateFluent<TEntity> AggregateWithIgnoreCaseCollation()
	{
		const string Locale = "en";

		var options = new AggregateOptions
		{
			Collation = new Collation(Locale, strength: CollationStrength.Primary)
		};

		return _mongoCollection.Aggregate(options);
	}

	protected async Task UpdateAsync(FilterDefinition<TEntity> filter, TEntity entity, CancellationToken cancellationToken)
	{
		var options = new ReplaceOptions { IsUpsert = false };

		if (_sessionHandler.ClientSessionHandle.HasNoActiveTransaction())
		{
			await _mongoCollection.ReplaceOneAsync(filter, entity, options, cancellationToken);

			return;
		}

		await _mongoCollection.ReplaceOneAsync(_sessionHandler.ClientSessionHandle, filter, entity, options, cancellationToken);
	}

	protected async Task DeleteAsync(FilterDefinition<TEntity> filter, CancellationToken cancellationToken)
	{
		if (_sessionHandler.ClientSessionHandle.HasNoActiveTransaction())
		{
			await _mongoCollection.DeleteOneAsync(filter, null, cancellationToken);

			return;
		}

		await _mongoCollection.DeleteOneAsync(_sessionHandler.ClientSessionHandle, filter, null, cancellationToken);
	}

	protected async Task DeleteRangeAsync(FilterDefinition<TEntity> filter, CancellationToken cancellationToken)
	{
		if (_sessionHandler.ClientSessionHandle.HasNoActiveTransaction())
		{
			await _mongoCollection.DeleteManyAsync(filter, null, cancellationToken);

			return;
		}

		await _mongoCollection.DeleteManyAsync(_sessionHandler.ClientSessionHandle, filter, null, cancellationToken);
	}

	public async Task AddAsync(TEntity entity, CancellationToken cancellationToken)
	{
		if (_sessionHandler.ClientSessionHandle.HasNoActiveTransaction())
		{
			await _mongoCollection.InsertOneAsync(entity, null, cancellationToken);

			return;
		}

		await _mongoCollection.InsertOneAsync(_sessionHandler.ClientSessionHandle, entity, null, cancellationToken);
	}

	public async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken)
	{
		if (_sessionHandler.ClientSessionHandle.HasNoActiveTransaction())
		{
			await _mongoCollection.InsertManyAsync(entities, null, cancellationToken);

			return;
		}

		await _mongoCollection.InsertManyAsync(_sessionHandler.ClientSessionHandle, entities, null, cancellationToken);
	}
}
