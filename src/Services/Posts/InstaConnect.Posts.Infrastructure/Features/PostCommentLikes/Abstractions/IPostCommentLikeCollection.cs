namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Abstractions;

public interface IPostCommentLikeCollection
{
	public IPostCommentLikeFluent AggregateFluent();

	public Task AddAsync(
		PostCommentLike entity,
		CancellationToken cancellationToken);

	public Task AddRangeAsync(
		IEnumerable<PostCommentLike> entities,
		CancellationToken cancellationToken);

	public Task DeleteAsync(
		PostCommentLike entity,
		CancellationToken cancellationToken);

	internal Task DeleteByParentAsync(
		FilterDefinition<PostCommentLike> filter,
		CancellationToken cancellationToken);
}
