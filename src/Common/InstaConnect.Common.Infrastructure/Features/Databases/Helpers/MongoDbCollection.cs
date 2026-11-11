using InstaConnect.Common.Infrastructure.Features.Databases.Extensions;
using InstaConnect.Common.Infrastructure.Features.Databases.Utilities;

namespace InstaConnect.Common.Infrastructure.Features.Databases.Helpers;

public abstract class MongoDbCollection<TEntity, TEntityId>
	where TEntity : IEntityWithId<TEntityId>
	where TEntityId : IEntityId
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
		var options = new AggregateOptions
		{
			Collation = MongoDbCollations.IgnoreCase
		};

		return _mongoCollection.Aggregate(options);
	}

	protected async Task ReplaceAsync(FilterDefinition<TEntity> filter, TEntity entity, CancellationToken cancellationToken)
	{
		var options = new ReplaceOptions { IsUpsert = false, Collation = MongoDbCollations.IgnoreCase };

		if (_sessionHandler.ClientSessionHandle.HasNoActiveTransaction())
		{
			await _mongoCollection.ReplaceOneAsync(filter, entity, options, cancellationToken);

			return;
		}

		await _mongoCollection.ReplaceOneAsync(_sessionHandler.ClientSessionHandle, filter, entity, options, cancellationToken);
	}

	protected async Task<List<TEntityId>> GetIdsAsync(FilterDefinition<TEntity> filter, CancellationToken cancellationToken)
	{
		return await AggregateWithIgnoreCaseCollation()
			.Match(filter)
			.Project(p => p.Id)
			.ToListAsync(cancellationToken);
	}

	protected async Task RemoveAsync(FilterDefinition<TEntity> filter, CancellationToken cancellationToken)
	{
		var options = new DeleteOptions { Collation = MongoDbCollations.IgnoreCase };

		if (_sessionHandler.ClientSessionHandle.HasNoActiveTransaction())
		{
			await _mongoCollection.DeleteOneAsync(filter, options, cancellationToken);

			return;
		}

		await _mongoCollection.DeleteOneAsync(_sessionHandler.ClientSessionHandle, filter, options, cancellationToken);
	}

	protected async Task RemoveRangeAsync(FilterDefinition<TEntity> filter, CancellationToken cancellationToken)
	{
		var options = new DeleteOptions { Collation = MongoDbCollations.IgnoreCase };

		if (_sessionHandler.ClientSessionHandle.HasNoActiveTransaction())
		{
			await _mongoCollection.DeleteManyAsync(filter, options, cancellationToken);

			return;
		}

		await _mongoCollection.DeleteManyAsync(_sessionHandler.ClientSessionHandle, filter, options, cancellationToken);
	}

	protected async Task InsertAsync(TEntity entity, CancellationToken cancellationToken)
	{
		if (_sessionHandler.ClientSessionHandle.HasNoActiveTransaction())
		{
			await _mongoCollection.InsertOneAsync(entity, null, cancellationToken);

			return;
		}

		await _mongoCollection.InsertOneAsync(_sessionHandler.ClientSessionHandle, entity, null, cancellationToken);
	}

	protected async Task InsertRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken)
	{
		if (_sessionHandler.ClientSessionHandle.HasNoActiveTransaction())
		{
			await _mongoCollection.InsertManyAsync(entities, null, cancellationToken);

			return;
		}

		await _mongoCollection.InsertManyAsync(_sessionHandler.ClientSessionHandle, entities, null, cancellationToken);
	}
}
