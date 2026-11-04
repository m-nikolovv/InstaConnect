using InstaConnect.Common.Infrastructure.Features.Databases.Models;
using InstaConnect.Common.Infrastructure.Features.Databases.Utilities;

using Microsoft.Extensions.Hosting;

namespace InstaConnect.Common.Infrastructure.Features.Databases.Helpers;

internal class MongoDbCollectionsHostedService : IHostedService
{
	private const int NamespaceExistsCode = 48;

	private readonly IMongoDatabase _database;
	private readonly IEnumerable<MongoDbCollectionDefinition> _collectionDefinitions;

	public MongoDbCollectionsHostedService(
		IMongoDatabase database,
		IEnumerable<MongoDbCollectionDefinition> collectionDefinitions)
	{
		_database = database;
		_collectionDefinitions = collectionDefinitions;
	}

	public async Task StartAsync(CancellationToken cancellationToken)
	{
		var existingNames = await (await _database.ListCollectionNamesAsync(cancellationToken: cancellationToken))
			.ToListAsync(cancellationToken);
		var missingNames = _collectionDefinitions
			.Select(c => c.Name)
			.Distinct()
			.Except(existingNames);

		foreach (var name in missingNames)
		{
			try
			{
				var options = new CreateCollectionOptions { Collation = MongoDbCollations.IgnoreCase };

				await _database.CreateCollectionAsync(name, options, cancellationToken);
			}
			catch (MongoCommandException exception)
			{
				if (exception.Code != NamespaceExistsCode)
				{
					throw;
				}
			}
		}
	}

	public Task StopAsync(CancellationToken cancellationToken)
	{
		return Task.CompletedTask;
	}
}
