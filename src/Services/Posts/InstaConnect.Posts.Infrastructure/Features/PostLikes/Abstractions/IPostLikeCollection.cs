namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Abstractions;

public interface IPostLikeCollection : IMongoDbCollection<PostLike>
{
	public IPostLikeFluent AggregateFluent();

	internal Task CascadeAddAsync(
		FilterDefinition<PostLike> filter,
		CancellationToken cancellationToken);

	internal Task CascadeUpdateAsync(
		FilterDefinition<PostLike> filter,
		CancellationToken cancellationToken);

	public Task DeleteAsync(
		PostLike entity,
		CancellationToken cancellationToken);

	internal Task CascadeDeleteAsync(
		FilterDefinition<PostLike> filter,
		CancellationToken cancellationToken);
}
