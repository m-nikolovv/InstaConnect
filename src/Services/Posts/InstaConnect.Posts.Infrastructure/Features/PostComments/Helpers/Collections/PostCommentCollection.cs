using InstaConnect.Posts.Infrastructure.Features.PostCommentImages.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.PostCommentImages.Extensions;
using InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Extensions;

namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Helpers.Collections;

internal class PostCommentCollection : MongoDbCollection<PostComment, PostCommentId>, IPostCommentCollection
{
	private readonly IPostCommentFluentFactory _fluentFactory;
	private readonly IPostCommentLikeCollection _commentLikeCollection;
	private readonly IPostCommentImageCollection _commentImageCollection;

	public PostCommentCollection(
		ISessionHandler sessionHandler,
		IPostCommentFluentFactory fluentFactory,
		IMongoCollection<PostComment> collection,
		IPostCommentLikeCollection commentLikeCollection,
		IPostCommentImageCollection commentImageCollection) : base(sessionHandler, collection)
	{
		_fluentFactory = fluentFactory;
		_commentLikeCollection = commentLikeCollection;
		_commentImageCollection = commentImageCollection;
	}

	public IPostCommentFluent AggregateFluent()
	{
		var fluent = AggregateWithIgnoreCaseCollation();

		return _fluentFactory.Create(fluent);
	}

	public async Task UpdateAsync(
		PostComment entity,
		CancellationToken cancellationToken)
	{
		await UpdateAsync(entity.Id.GetFilter(), entity, cancellationToken);
	}

	public async Task DeleteAsync(
		PostComment entity,
		CancellationToken cancellationToken)
	{
		await CascadeDeleteAsync(entity.Id.GetFilter(), cancellationToken);
	}

	public async Task CascadeDeleteAsync(
		FilterDefinition<PostComment> filter,
		CancellationToken cancellationToken)
	{
		var commentIds = await GetIdsAsync(filter, cancellationToken);

		await _commentImageCollection.CascadeDeleteAsync(commentIds.GetPostCommentImageCascadeFilter(), cancellationToken);
		await _commentLikeCollection.CascadeDeleteAsync(commentIds.GetPostCommentLikeCascadeFilter(), cancellationToken);
		await DeleteRangeAsync(filter, cancellationToken);
	}
}
