namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Abstractions;

public interface IPostLikeCollection : IMongoDbCollection<PostLike>
{
	public IPostLikeFluent AggregateFluent();

	public Task DeleteAsync(
		PostLike entity,
		CancellationToken cancellationToken);
}
