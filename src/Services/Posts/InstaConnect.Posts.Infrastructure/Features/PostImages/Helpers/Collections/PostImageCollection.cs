using InstaConnect.Posts.Domain.Features.PostImages.Models.ValueObjects;
using InstaConnect.Posts.Infrastructure.Features.PostImages.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.PostImages.Extensions;

namespace InstaConnect.Posts.Infrastructure.Features.PostImages.Helpers.Collections;

internal class PostImageCollection : IPostImageCollection
{
	private readonly IPostImageFluentFactory _fluentFactory;
	private readonly IMongoDbCollectionHandler<PostImage, PostImageId> _collectionHandler;

	public PostImageCollection(
		IPostImageFluentFactory fluentFactory,
		IMongoDbCollectionHandler<PostImage, PostImageId> collectionHandler)
	{
		_fluentFactory = fluentFactory;
		_collectionHandler = collectionHandler;
	}

	public IPostImageFluent AggregateFluent()
	{
		var fluent = _collectionHandler.AggregateWithIgnoreCaseCollation();

		return _fluentFactory.Create(fluent);
	}

	public async Task AddAsync(
		PostImage entity,
		CancellationToken cancellationToken)
	{
		await _collectionHandler.InsertAsync(entity, cancellationToken);
	}

	public async Task AddRangeAsync(
		IEnumerable<PostImage> entities,
		CancellationToken cancellationToken)
	{
		await _collectionHandler.InsertRangeAsync(entities, cancellationToken);
	}

	public async Task DeleteAsync(
		PostImage entity,
		CancellationToken cancellationToken)
	{
		await _collectionHandler.RemoveAsync(entity.Id.GetFilter(), cancellationToken);
	}

	public async Task DeleteByParentAsync(
		FilterDefinition<PostImage> filter,
		CancellationToken cancellationToken)
	{
		await _collectionHandler.RemoveRangeAsync(filter, cancellationToken);
	}

	public async Task DeleteRangeAsync(
		IEnumerable<PostImage> entities,
		CancellationToken cancellationToken)
	{
		await _collectionHandler.RemoveRangeAsync(entities.Select(p => p.Id).GetFilter(), cancellationToken);
	}
}
