namespace InstaConnect.Common.Infrastructure.Features.Databases.Abstractions;

public interface IMongoDbCollectionInitializer
{
	public Task InitializeAsync(CancellationToken cancellationToken);

	public Task SeedAsync(CancellationToken cancellationToken);
}
