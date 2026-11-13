using InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Extensions;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Helpers.Collections;

internal class PostCommentLikeCollection : IPostCommentLikeCollection
{
	private readonly IPostCommentLikeFluentFactory _fluentFactory;
	private readonly IMongoDbCollectionHandler<PostCommentLike, PostCommentLikeId> _collectionHandler;

	public PostCommentLikeCollection(
		IPostCommentLikeFluentFactory fluentFactory,
		IMongoDbCollectionHandler<PostCommentLike, PostCommentLikeId> collectionHandler)
	{
		_fluentFactory = fluentFactory;
		_collectionHandler = collectionHandler;
	}

	public IPostCommentLikeFluent AggregateFluent()
	{
		var fluent = _collectionHandler.AggregateWithIgnoreCaseCollation();

		return _fluentFactory.Create(fluent);
	}

	public async Task AddAsync(
		PostCommentLike entity,
		CancellationToken cancellationToken)
	{
		await _collectionHandler.InsertAsync(entity, cancellationToken);
	}

	public async Task AddRangeAsync(
		IEnumerable<PostCommentLike> entities,
		CancellationToken cancellationToken)
	{
		await _collectionHandler.InsertRangeAsync(entities, cancellationToken);
	}

	public async Task DeleteAsync(
		PostCommentLike entity,
		CancellationToken cancellationToken)
	{
		await _collectionHandler.RemoveAsync(entity.Id.GetFilter(), cancellationToken);
	}

	public async Task DeleteByParentAsync(
		FilterDefinition<PostCommentLike> filter,
		CancellationToken cancellationToken)
	{
		await _collectionHandler.RemoveRangeAsync(filter, cancellationToken);
	}
}
