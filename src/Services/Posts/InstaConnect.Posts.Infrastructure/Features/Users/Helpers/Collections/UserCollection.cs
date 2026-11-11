using InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Extensions;
using InstaConnect.Posts.Infrastructure.Features.PostLikes.Extensions;

namespace InstaConnect.Posts.Infrastructure.Features.Users.Helpers.Collections;

internal class UserCollection : MongoDbCollection<User, UserId>, IUserCollection
{
	private readonly IUserCacheHandler _cacheHandler;
	private readonly IPostCollection _postCollection;
	private readonly IUserFluentFactory _fluentFactory;
	private readonly IPostLikeCollection _likeCollection;
	private readonly IPostCommentCollection _commentCollection;
	private readonly IPostCommentLikeCollection _commentLikeCollection;

	public UserCollection(
		ISessionHandler sessionHandler,
		IUserCacheHandler cacheHandler,
		IPostCollection postCollection,
		IUserFluentFactory fluentFactory,
		IMongoCollection<User> collection,
		IPostLikeCollection likeCollection,
		IPostCommentCollection commentCollection,
		IPostCommentLikeCollection commentLikeCollection) : base(sessionHandler, collection)
	{
		_cacheHandler = cacheHandler;
		_fluentFactory = fluentFactory;
		_likeCollection = likeCollection;
		_postCollection = postCollection;
		_commentCollection = commentCollection;
		_commentLikeCollection = commentLikeCollection;
	}

	public IUserFluent AggregateFluent()
	{
		var fluent = AggregateWithIgnoreCaseCollation();

		return _fluentFactory.Create(fluent);
	}

	public async Task AddAsync(
		User entity,
		CancellationToken cancellationToken)
	{
		await _postCollection.CascadeAddAsync(entity.Id.GetPostCascadeFilter(), cancellationToken);
		await _likeCollection.CascadeAddAsync(entity.Id.GetPostLikeCascadeFilter(), cancellationToken);
		await _commentCollection.CascadeAddAsync(entity.Id.GetPostCommentCascadeFilter(), cancellationToken);
		await _commentLikeCollection.CascadeAddAsync(entity.Id.GetPostCommentLikeCascadeFilter(), cancellationToken);
		await InsertAsync(entity, cancellationToken);
		await _cacheHandler.DeleteAsync(entity.Id);
	}

	public async Task AddRangeAsync(
		IEnumerable<User> entities,
		CancellationToken cancellationToken)
	{
		await InsertRangeAsync(entities, cancellationToken);
		await _cacheHandler.DeleteRangeAsync(entities.Select(p => p.Id));
	}

	public async Task UpdateAsync(
		User entity,
		CancellationToken cancellationToken)
	{
		await _postCollection.CascadeUpdateAsync(entity.Id.GetPostCascadeFilter(), cancellationToken);
		await _likeCollection.CascadeUpdateAsync(entity.Id.GetPostLikeCascadeFilter(), cancellationToken);
		await _commentCollection.CascadeUpdateAsync(entity.Id.GetPostCommentCascadeFilter(), cancellationToken);
		await _commentLikeCollection.CascadeUpdateAsync(entity.Id.GetPostCommentLikeCascadeFilter(), cancellationToken);
		await ReplaceAsync(entity.Id.GetFilter(), entity, cancellationToken);
		await _cacheHandler.DeleteAsync(entity.Id);
	}

	public async Task DeleteAsync(
		User entity,
		CancellationToken cancellationToken)
	{
		await _postCollection.CascadeDeleteAsync(entity.Id.GetPostCascadeFilter(), cancellationToken);
		await _likeCollection.CascadeDeleteAsync(entity.Id.GetPostLikeCascadeFilter(), cancellationToken);
		await _commentCollection.CascadeDeleteAsync(entity.Id.GetPostCommentCascadeFilter(), cancellationToken);
		await _commentLikeCollection.CascadeDeleteAsync(entity.Id.GetPostCommentLikeCascadeFilter(), cancellationToken);
		await RemoveAsync(entity.Id.GetFilter(), cancellationToken);
		await _cacheHandler.DeleteAsync(entity.Id);
	}
}
