namespace InstaConnect.Posts.Infrastructure.Features.PostCommentImages.Abstractions;

public interface IPostCommentImageCollection : IMongoDbCollection<PostCommentImage>
{
	public IPostCommentImageFluent AggregateFluent();

	internal Task CascadeAddAsync(
		FilterDefinition<PostCommentImage> filter,
		CancellationToken cancellationToken);

	internal Task CascadeUpdateAsync(
		FilterDefinition<PostCommentImage> filter,
		CancellationToken cancellationToken);

	public Task DeleteAsync(
		PostCommentImage entity,
		CancellationToken cancellationToken);

	internal Task CascadeDeleteAsync(
		FilterDefinition<PostCommentImage> filter,
		CancellationToken cancellationToken);

	public Task DeleteRangeAsync(
		IEnumerable<PostCommentImage> entities,
		CancellationToken cancellationToken);
}
