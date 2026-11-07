using InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Extensions;
using InstaConnect.Posts.Infrastructure.Features.PostLikes.Extensions;

namespace InstaConnect.Posts.Infrastructure.Features.Users.Helpers.Collections;

internal class UserCollection : MongoDbCollection<User, UserId>, IUserCollection
{
	private readonly IPostCollection _postCollection;
	private readonly IUserFluentFactory _fluentFactory;
	private readonly IPostLikeCollection _likeCollection;
	private readonly IPostCommentCollection _commentCollection;
	private readonly IPostCommentLikeCollection _commentLikeCollection;

	public UserCollection(
		ISessionHandler sessionHandler,
		IPostCollection postCollection,
		IUserFluentFactory fluentFactory,
		IMongoCollection<User> collection,
		IPostLikeCollection likeCollection,
		IPostCommentCollection commentCollection,
		IPostCommentLikeCollection commentLikeCollection) : base(sessionHandler, collection)
	{
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

	public async Task UpdateAsync(
		User entity,
		CancellationToken cancellationToken)
	{
		await UpdateAsync(entity.Id.GetFilter(), entity, cancellationToken);
	}

	public async Task DeleteAsync(
		User entity,
		CancellationToken cancellationToken)
	{
		await _postCollection.CascadeDeleteAsync(entity.Id.GetPostCascadeFilter(), cancellationToken);
		await _likeCollection.CascadeDeleteAsync(entity.Id.GetPostLikeCascadeFilter(), cancellationToken);
		await _commentCollection.CascadeDeleteAsync(entity.Id.GetPostCommentCascadeFilter(), cancellationToken);
		await _commentLikeCollection.CascadeDeleteAsync(entity.Id.GetPostCommentLikeCascadeFilter(), cancellationToken);
		await DeleteAsync(entity.Id.GetFilter(), cancellationToken);
	}
}
