namespace InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;

public interface IPostCollection : IMongoDbCollection<Post>
{
	public IPostFluent AggregateFluent();

	internal Task CascadeAddAsync(
		FilterDefinition<Post> filter,
		CancellationToken cancellationToken);

	public Task UpdateAsync(
		Post entity,
		CancellationToken cancellationToken);

	internal Task CascadeUpdateAsync(
		FilterDefinition<Post> filter,
		CancellationToken cancellationToken);

	public Task DeleteAsync(
		Post entity,
		CancellationToken cancellationToken);

	internal Task CascadeDeleteAsync(
		FilterDefinition<Post> filter,
		CancellationToken cancellationToken);
}
