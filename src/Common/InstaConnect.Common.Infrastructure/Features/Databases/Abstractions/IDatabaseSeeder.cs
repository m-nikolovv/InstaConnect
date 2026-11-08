namespace InstaConnect.Common.Infrastructure.Features.Databases.Abstractions;

public interface IDatabaseSeeder
{
	public Task SeedAsync(CancellationToken cancellationToken);
}
