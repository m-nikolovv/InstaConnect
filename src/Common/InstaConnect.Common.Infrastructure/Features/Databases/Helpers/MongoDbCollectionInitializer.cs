using InstaConnect.Common.Infrastructure.Features.Databases.Utilities;

namespace InstaConnect.Common.Infrastructure.Features.Databases.Helpers;

public abstract class MongoDbCollectionInitializer<TEntity> : IMongoDbCollectionInitializer
{
	private readonly IMongoCollection<TEntity> _collection;
	private readonly ICollection<CreateIndexModel<TEntity>> _indexes;

	protected MongoDbCollectionInitializer(
		IMongoCollection<TEntity> collection,
		ICollection<CreateIndexModel<TEntity>> indexes)
	{
		_collection = collection;
		_indexes = indexes;
	}

	public async Task InitializeAsync(CancellationToken cancellationToken)
	{
		var name = _collection.CollectionNamespace.CollectionName;
		var cursor = await _collection.Database.ListCollectionNamesAsync(cancellationToken: cancellationToken);
		var existingNames = await cursor.ToListAsync(cancellationToken);

		if (!existingNames.Contains(name))
		{
			var createOptions = new CreateCollectionOptions { Collation = MongoDbCollations.IgnoreCase };

			await _collection.Database.CreateCollectionAsync(name, createOptions, cancellationToken);
		}

		await _collection.Indexes.CreateManyAsync(_indexes, cancellationToken);
	}
}
