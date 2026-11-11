namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Abstractions;

public interface IPostCommentLikeCollection : IMongoDbCollection<PostCommentLike>
{
	public IPostCommentLikeFluent AggregateFluent();

	internal Task AddByParentAsync(
		FilterDefinition<PostCommentLike> filter,
		CancellationToken cancellationToken);

	internal Task UpdateByParentAsync(
		FilterDefinition<PostCommentLike> filter,
		CancellationToken cancellationToken);

	public Task DeleteAsync(
		PostCommentLike entity,
		CancellationToken cancellationToken);

	internal Task DeleteByParentAsync(
		FilterDefinition<PostCommentLike> filter,
		CancellationToken cancellationToken);
}
