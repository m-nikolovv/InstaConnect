namespace InstaConnect.Posts.Infrastructure.Features.PostCommentImages.Abstractions;

public interface IPostCommentImageCollection : IMongoDbCollection<PostCommentImage>
{
	public IPostCommentImageFluent AggregateFluent();

	internal Task AddByParentAsync(
		FilterDefinition<PostCommentImage> filter,
		CancellationToken cancellationToken);

	internal Task UpdateByParentAsync(
		FilterDefinition<PostCommentImage> filter,
		CancellationToken cancellationToken);

	public Task DeleteAsync(
		PostCommentImage entity,
		CancellationToken cancellationToken);

	internal Task DeleteByParentAsync(
		FilterDefinition<PostCommentImage> filter,
		CancellationToken cancellationToken);

	public Task DeleteRangeAsync(
		IEnumerable<PostCommentImage> entities,
		CancellationToken cancellationToken);
}
