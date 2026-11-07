namespace InstaConnect.Common.Infrastructure.Features.Databases.Abstractions;

public interface IDatabaseInitializer
{
	public Task InitializeAsync(CancellationToken cancellationToken);
}
