namespace InstaConnect.Posts.Infrastructure.Features.PostCommentImages.Abstractions;

public interface IPostCommentImageCollection : IMongoDbCollection<PostCommentImage>
{
	public IPostCommentImageFluent AggregateFluent();

	public Task DeleteAsync(
		PostCommentImage entity,
		CancellationToken cancellationToken);

	public Task DeleteRangeAsync(
		IEnumerable<PostCommentImage> entities,
		CancellationToken cancellationToken);
}
