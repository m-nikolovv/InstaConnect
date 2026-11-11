using InstaConnect.Posts.Domain.Features.PostImages.Models.ValueObjects;
using InstaConnect.Posts.Infrastructure.Features.PostImages.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.PostImages.Extensions;

namespace InstaConnect.Posts.Infrastructure.Features.PostImages.Helpers.Collections;

internal class PostImageCollection : MongoDbCollection<PostImage, PostImageId>, IPostImageCollection
{
	private readonly IPostCacheHandler _cacheHandler;
	private readonly IPostImageFluentFactory _fluentFactory;
	private readonly IPostImageCacheHandler _imageCacheHandler;

	public PostImageCollection(
		ISessionHandler sessionHandler,
		IPostCacheHandler cacheHandler,
		IPostImageFluentFactory fluentFactory,
		IMongoCollection<PostImage> collection,
		IPostImageCacheHandler imageCacheHandler) : base(sessionHandler, collection)
	{
		_cacheHandler = cacheHandler;
		_fluentFactory = fluentFactory;
		_imageCacheHandler = imageCacheHandler;
	}

	public IPostImageFluent AggregateFluent()
	{
		var fluent = AggregateWithIgnoreCaseCollation();

		return _fluentFactory.Create(fluent);
	}

	public async Task AddAsync(
		PostImage entity,
		CancellationToken cancellationToken)
	{
		await InsertAsync(entity, cancellationToken);
		await _cacheHandler.DeleteResponseAsync(entity.Id.Id);
		await _imageCacheHandler.DeleteAsync(entity.Id);
	}

	public async Task CascadeAddAsync(
		FilterDefinition<PostImage> filter,
		CancellationToken cancellationToken)
	{
		var imageIds = await GetIdsAsync(filter, cancellationToken);

		await _cacheHandler.DeleteResponseRangeAsync(imageIds.Select(p => p.Id));
		await _imageCacheHandler.DeleteRangeAsync(imageIds);
	}

	public async Task AddRangeAsync(
		IEnumerable<PostImage> entities,
		CancellationToken cancellationToken)
	{
		await InsertRangeAsync(entities, cancellationToken);
		await _cacheHandler.DeleteResponseRangeAsync(entities.Select(p => p.Id.Id));
		await _imageCacheHandler.DeleteRangeAsync(entities.Select(p => p.Id));
	}

	public async Task CascadeUpdateAsync(
		FilterDefinition<PostImage> filter,
		CancellationToken cancellationToken)
	{
		var imageIds = await GetIdsAsync(filter, cancellationToken);

		await _imageCacheHandler.DeleteRangeAsync(imageIds);
	}

	public async Task DeleteAsync(
		PostImage entity,
		CancellationToken cancellationToken)
	{
		await RemoveAsync(entity.Id.GetFilter(), cancellationToken);
		await _cacheHandler.DeleteResponseAsync(entity.Id.Id);
		await _imageCacheHandler.DeleteAsync(entity.Id);
	}

	public async Task CascadeDeleteAsync(
		FilterDefinition<PostImage> filter,
		CancellationToken cancellationToken)
	{
		var imageIds = await GetIdsAsync(filter, cancellationToken);

		await RemoveRangeAsync(filter, cancellationToken);
		await _cacheHandler.DeleteResponseRangeAsync(imageIds.Select(p => p.Id));
		await _imageCacheHandler.DeleteRangeAsync(imageIds);
	}

	public async Task DeleteRangeAsync(
		IEnumerable<PostImage> entities,
		CancellationToken cancellationToken)
	{
		await RemoveRangeAsync(entities.Select(p => p.Id).GetFilter(), cancellationToken);
		await _cacheHandler.DeleteResponseRangeAsync(entities.Select(p => p.Id.Id));
		await _imageCacheHandler.DeleteRangeAsync(entities.Select(p => p.Id));
	}
}
