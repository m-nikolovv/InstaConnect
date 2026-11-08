namespace InstaConnect.Common.Infrastructure.Features.Databases.Helpers;

internal class DatabaseSeeder : IDatabaseSeeder
{
	private readonly IEnumerable<IMongoDbCollectionSeeder> _collectionSeeders;

	public DatabaseSeeder(IEnumerable<IMongoDbCollectionSeeder> collectionSeeders)
	{
		_collectionSeeders = collectionSeeders;
	}

	public async Task SeedAsync(CancellationToken cancellationToken)
	{
		foreach (var collectionSeeder in _collectionSeeders)
		{
			await collectionSeeder.SeedAsync(cancellationToken);
		}
	}
}
