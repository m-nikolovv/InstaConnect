using InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Extensions;
using InstaConnect.Posts.Infrastructure.Features.PostLikes.Extensions;

namespace InstaConnect.Posts.Infrastructure.Features.Users.Helpers.Collections;

internal class UserCollection : IUserCollection
{
	private readonly IPostCollection _postCollection;
	private readonly IUserFluentFactory _fluentFactory;
	private readonly IPostLikeCollection _likeCollection;
	private readonly IPostCommentCollection _commentCollection;
	private readonly IPostCommentLikeCollection _commentLikeCollection;
	private readonly IMongoDbCollectionHandler<User, UserId> _collectionHandler;

	public UserCollection(
		IPostCollection postCollection,
		IUserFluentFactory fluentFactory,
		IPostLikeCollection likeCollection,
		IPostCommentCollection commentCollection,
		IPostCommentLikeCollection commentLikeCollection,
		IMongoDbCollectionHandler<User, UserId> collectionHandler)
	{
		_fluentFactory = fluentFactory;
		_likeCollection = likeCollection;
		_postCollection = postCollection;
		_commentCollection = commentCollection;
		_collectionHandler = collectionHandler;
		_commentLikeCollection = commentLikeCollection;
	}

	public IUserFluent AggregateFluent()
	{
		var fluent = _collectionHandler.AggregateWithIgnoreCaseCollation();

		return _fluentFactory.Create(fluent);
	}

	public async Task AddAsync(
		User entity,
		CancellationToken cancellationToken)
	{
		await _collectionHandler.InsertAsync(entity, cancellationToken);
	}

	public async Task AddRangeAsync(
		IEnumerable<User> entities,
		CancellationToken cancellationToken)
	{
		await _collectionHandler.InsertRangeAsync(entities, cancellationToken);
	}

	public async Task UpdateAsync(
		User entity,
		CancellationToken cancellationToken)
	{
		await _collectionHandler.ReplaceAsync(entity.Id.GetFilter(), entity, cancellationToken);
	}

	public async Task DeleteAsync(
		User entity,
		CancellationToken cancellationToken)
	{
		await _postCollection.DeleteByParentAsync(entity.Id.GetPostByParentFilter(), cancellationToken);
		await _likeCollection.DeleteByParentAsync(entity.Id.GetPostLikeByParentFilter(), cancellationToken);
		await _commentCollection.DeleteByParentAsync(entity.Id.GetPostCommentByParentFilter(), cancellationToken);
		await _commentLikeCollection.DeleteByParentAsync(entity.Id.GetPostCommentLikeByParentFilter(), cancellationToken);
		await _collectionHandler.RemoveAsync(entity.Id.GetFilter(), cancellationToken);
	}
}
