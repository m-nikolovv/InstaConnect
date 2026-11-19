namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Abstractions;

public interface IPostLikeCollection
{
	public IPostLikeFluent AggregateFluent();

	public Task AddAsync(
		PostLike entity,
		CancellationToken cancellationToken);

	public Task AddRangeAsync(
		IEnumerable<PostLike> entities,
		CancellationToken cancellationToken);

	public Task DeleteAsync(
		PostLike entity,
		CancellationToken cancellationToken);

	internal Task DeleteByParentAsync(
		FilterDefinition<PostLike> filter,
		CancellationToken cancellationToken);
}
