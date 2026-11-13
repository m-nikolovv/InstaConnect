using InstaConnect.Posts.Infrastructure.Features.PostCommentImages.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.PostCommentImages.Extensions;
using InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Extensions;

namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Helpers.Collections;

internal class PostCommentCollection : IPostCommentCollection
{
	private readonly IPostCommentFluentFactory _fluentFactory;
	private readonly IPostCommentLikeCollection _commentLikeCollection;
	private readonly IPostCommentImageCollection _commentImageCollection;
	private readonly IMongoDbCollectionHandler<PostComment, PostCommentId> _collectionHandler;

	public PostCommentCollection(
		IPostCommentFluentFactory fluentFactory,
		IPostCommentLikeCollection commentLikeCollection,
		IPostCommentImageCollection commentImageCollection,
		IMongoDbCollectionHandler<PostComment, PostCommentId> collectionHandler)
	{
		_fluentFactory = fluentFactory;
		_collectionHandler = collectionHandler;
		_commentLikeCollection = commentLikeCollection;
		_commentImageCollection = commentImageCollection;
	}

	public IPostCommentFluent AggregateFluent()
	{
		var fluent = _collectionHandler.AggregateWithIgnoreCaseCollation();

		return _fluentFactory.Create(fluent);
	}

	public async Task AddAsync(
		PostComment entity,
		CancellationToken cancellationToken)
	{
		await _collectionHandler.InsertAsync(entity, cancellationToken);
	}

	public async Task AddRangeAsync(
		IEnumerable<PostComment> entities,
		CancellationToken cancellationToken)
	{
		await _collectionHandler.InsertRangeAsync(entities, cancellationToken);
	}

	public async Task UpdateAsync(
		PostComment entity,
		CancellationToken cancellationToken)
	{
		await _collectionHandler.ReplaceAsync(entity.Id.GetFilter(), entity, cancellationToken);
	}

	public async Task DeleteAsync(
		PostComment entity,
		CancellationToken cancellationToken)
	{
		await _commentImageCollection.DeleteByParentAsync(entity.Id.GetPostCommentImageByParentFilter(), cancellationToken);
		await _commentLikeCollection.DeleteByParentAsync(entity.Id.GetPostCommentLikeByParentFilter(), cancellationToken);
		await _collectionHandler.RemoveAsync(entity.Id.GetFilter(), cancellationToken);
	}

	public async Task DeleteByParentAsync(
		FilterDefinition<PostComment> filter,
		CancellationToken cancellationToken)
	{
		var commentIds = await AggregateFluent()
			.Match(filter)
			.GetIdsAsync(cancellationToken);

		await _commentImageCollection.DeleteByParentAsync(commentIds.GetPostCommentImageByParentFilter(), cancellationToken);
		await _commentLikeCollection.DeleteByParentAsync(commentIds.GetPostCommentLikeByParentFilter(), cancellationToken);
		await _collectionHandler.RemoveRangeAsync(filter, cancellationToken);
	}
}
