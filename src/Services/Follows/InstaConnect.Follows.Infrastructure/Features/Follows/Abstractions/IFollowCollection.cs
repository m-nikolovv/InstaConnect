namespace InstaConnect.Follows.Infrastructure.Features.Follows.Abstractions;

public interface IFollowCollection : IMongoDbCollection<Follow>
{
	public IFollowFluent AggregateFluent();

	internal Task CascadeAddAsync(
		FilterDefinition<Follow> filter,
		CancellationToken cancellationToken);

	internal Task CascadeUpdateAsync(
		FilterDefinition<Follow> filter,
		CancellationToken cancellationToken);

	public Task DeleteAsync(
		Follow entity,
		CancellationToken cancellationToken);

	internal Task CascadeDeleteAsync(
		FilterDefinition<Follow> filter,
		CancellationToken cancellationToken);
}
