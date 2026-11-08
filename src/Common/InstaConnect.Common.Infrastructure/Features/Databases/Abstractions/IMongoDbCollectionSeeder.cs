namespace InstaConnect.Common.Infrastructure.Features.Databases.Abstractions;

public interface IMongoDbCollectionSeeder
{
	public Task SeedAsync(CancellationToken cancellationToken);
}
