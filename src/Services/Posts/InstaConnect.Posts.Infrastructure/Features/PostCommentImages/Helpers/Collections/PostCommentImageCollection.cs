using InstaConnect.Posts.Domain.Features.PostCommentImages.Models.ValueObjects;
using InstaConnect.Posts.Infrastructure.Features.PostCommentImages.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.PostCommentImages.Extensions;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentImages.Helpers.Collections;

internal class PostCommentImageCollection : IPostCommentImageCollection
{
	private readonly IPostCommentImageFluentFactory _fluentFactory;
	private readonly IMongoDbCollectionHandler<PostCommentImage, PostCommentImageId> _collectionHandler;

	public PostCommentImageCollection(
		IPostCommentImageFluentFactory fluentFactory,
		IMongoDbCollectionHandler<PostCommentImage, PostCommentImageId> collectionHandler)
	{
		_fluentFactory = fluentFactory;
		_collectionHandler = collectionHandler;
	}

	public IPostCommentImageFluent AggregateFluent()
	{
		var fluent = _collectionHandler.AggregateWithIgnoreCaseCollation();

		return _fluentFactory.Create(fluent);
	}

	public async Task AddAsync(
		PostCommentImage entity,
		CancellationToken cancellationToken)
	{
		await _collectionHandler.InsertAsync(entity, cancellationToken);
	}

	public async Task AddRangeAsync(
		IEnumerable<PostCommentImage> entities,
		CancellationToken cancellationToken)
	{
		await _collectionHandler.InsertRangeAsync(entities, cancellationToken);
	}

	public async Task DeleteAsync(
		PostCommentImage entity,
		CancellationToken cancellationToken)
	{
		await _collectionHandler.RemoveAsync(entity.Id.GetFilter(), cancellationToken);
	}

	public async Task DeleteByParentAsync(
		FilterDefinition<PostCommentImage> filter,
		CancellationToken cancellationToken)
	{
		await _collectionHandler.RemoveRangeAsync(filter, cancellationToken);
	}

	public async Task DeleteRangeAsync(
		IEnumerable<PostCommentImage> entities,
		CancellationToken cancellationToken)
	{
		await _collectionHandler.RemoveRangeAsync(entities.Select(p => p.Id).GetFilter(), cancellationToken);
	}
}
