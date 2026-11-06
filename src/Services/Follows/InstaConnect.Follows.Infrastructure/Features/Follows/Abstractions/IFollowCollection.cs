namespace InstaConnect.Follows.Infrastructure.Features.Follows.Abstractions;

public interface IFollowCollection : IMongoDbCollection<Follow>
{
	public IFollowFluent AggregateFluent();

	public Task DeleteAsync(
		Follow entity,
		CancellationToken cancellationToken);

	internal Task CascadeDeleteAsync(
		FilterDefinition<Follow> filter,
		CancellationToken cancellationToken);
}
