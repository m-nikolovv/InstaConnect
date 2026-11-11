namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Abstractions;

public interface IPostLikeCollection : IMongoDbCollection<PostLike>
{
	public IPostLikeFluent AggregateFluent();

	internal Task AddByParentAsync(
		FilterDefinition<PostLike> filter,
		CancellationToken cancellationToken);

	internal Task UpdateByParentAsync(
		FilterDefinition<PostLike> filter,
		CancellationToken cancellationToken);

	public Task DeleteAsync(
		PostLike entity,
		CancellationToken cancellationToken);

	internal Task DeleteByParentAsync(
		FilterDefinition<PostLike> filter,
		CancellationToken cancellationToken);
}
