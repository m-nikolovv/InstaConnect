namespace InstaConnect.Posts.Infrastructure.Features.PostCommentImages.Abstractions;

public interface IPostCommentImageCollection
{
	public IPostCommentImageFluent AggregateFluent();

	public Task AddAsync(
		PostCommentImage entity,
		CancellationToken cancellationToken);

	public Task AddRangeAsync(
		IEnumerable<PostCommentImage> entities,
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
