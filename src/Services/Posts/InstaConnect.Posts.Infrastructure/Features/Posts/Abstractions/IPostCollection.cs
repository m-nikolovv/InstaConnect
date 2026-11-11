namespace InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;

public interface IPostCollection : IMongoDbCollection<Post>
{
	public IPostFluent AggregateFluent();

	internal Task AddByParentAsync(
		FilterDefinition<Post> filter,
		CancellationToken cancellationToken);

	public Task UpdateAsync(
		Post entity,
		CancellationToken cancellationToken);

	internal Task UpdateByParentAsync(
		FilterDefinition<Post> filter,
		CancellationToken cancellationToken);

	public Task DeleteAsync(
		Post entity,
		CancellationToken cancellationToken);

	internal Task DeleteByParentAsync(
		FilterDefinition<Post> filter,
		CancellationToken cancellationToken);
}
