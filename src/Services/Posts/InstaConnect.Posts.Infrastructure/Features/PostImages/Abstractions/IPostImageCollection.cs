namespace InstaConnect.Posts.Infrastructure.Features.PostImages.Abstractions;

public interface IPostImageCollection : IMongoDbCollection<PostImage>
{
	public IPostImageFluent AggregateFluent();

	internal Task AddByParentAsync(
		FilterDefinition<PostImage> filter,
		CancellationToken cancellationToken);

	internal Task UpdateByParentAsync(
		FilterDefinition<PostImage> filter,
		CancellationToken cancellationToken);

	public Task DeleteAsync(
		PostImage entity,
		CancellationToken cancellationToken);

	internal Task DeleteByParentAsync(
		FilterDefinition<PostImage> filter,
		CancellationToken cancellationToken);

	public Task DeleteRangeAsync(
		IEnumerable<PostImage> entities,
		CancellationToken cancellationToken);
}
