using InstaConnect.Common.Infrastructure.Features.Databases.Models;

using Microsoft.Extensions.Hosting;

namespace InstaConnect.Common.Infrastructure.Features.Databases.Helpers;

internal class MongoDbIndexesHostedService : IHostedService
{
	private readonly IMongoDatabase _database;
	private readonly IEnumerable<MongoDbCollectionIndexes> _collectionIndexes;

	public MongoDbIndexesHostedService(
		IMongoDatabase database,
		IEnumerable<MongoDbCollectionIndexes> collectionIndexes)
	{
		_database = database;
		_collectionIndexes = collectionIndexes;
	}

	public async Task StartAsync(CancellationToken cancellationToken)
	{
		foreach (var collectionIndexes in _collectionIndexes)
		{
			await collectionIndexes.CreateAsync(_database, cancellationToken);
		}
	}

	public Task StopAsync(CancellationToken cancellationToken)
	{
		return Task.CompletedTask;
	}
}
