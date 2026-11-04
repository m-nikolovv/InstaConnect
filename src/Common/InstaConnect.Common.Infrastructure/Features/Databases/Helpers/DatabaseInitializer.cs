namespace InstaConnect.Common.Infrastructure.Features.Databases.Helpers;

internal class DatabaseInitializer : IDatabaseInitializer
{
	private readonly IEnumerable<IMongoDbCollectionInitializer> _collectionInitializers;

	public DatabaseInitializer(IEnumerable<IMongoDbCollectionInitializer> collectionInitializers)
	{
		_collectionInitializers = collectionInitializers;
	}

	public async Task InitializeAsync(CancellationToken cancellationToken)
	{
		foreach (var collectionInitializer in _collectionInitializers)
		{
			await collectionInitializer.InitializeAsync(cancellationToken);
			await collectionInitializer.SeedAsync(cancellationToken);
		}
	}
}
