namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Abstractions;

public interface IPostCommentLikeCollection : IMongoDbCollection<PostCommentLike>
{
	public IPostCommentLikeFluent AggregateFluent();

	internal Task CascadeAddAsync(
		FilterDefinition<PostCommentLike> filter,
		CancellationToken cancellationToken);

	internal Task CascadeUpdateAsync(
		FilterDefinition<PostCommentLike> filter,
		CancellationToken cancellationToken);

	public Task DeleteAsync(
		PostCommentLike entity,
		CancellationToken cancellationToken);

	internal Task CascadeDeleteAsync(
		FilterDefinition<PostCommentLike> filter,
		CancellationToken cancellationToken);
}
