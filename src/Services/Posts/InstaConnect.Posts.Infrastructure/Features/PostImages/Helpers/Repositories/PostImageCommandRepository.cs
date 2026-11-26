using InstaConnect.Posts.Domain.Features.PostImages.Abstractions;
using InstaConnect.Posts.Domain.Features.PostImages.Models.ValueObjects;
using InstaConnect.Posts.Infrastructure.Features.PostImages.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Features.PostImages.Helpers.Repositories;

internal class PostImageCommandRepository : IPostImageCommandRepository
{
	private readonly IPostCacheHandler _cacheHandler;
	private readonly IPostImageCollection _collection;
	private readonly IPostImageCacheHandler _imageCacheHandler;

	public PostImageCommandRepository(
		IPostCacheHandler cacheHandler,
		IPostImageCollection collection,
		IPostImageCacheHandler imageCacheHandler)
	{
		_cacheHandler = cacheHandler;
		_collection = collection;
		_imageCacheHandler = imageCacheHandler;
	}

	public async Task<PostImage?> GetByIdAsync(
		PostImageId id,
		CancellationToken cancellationToken)
	{
		return await _collection
			.AggregateFluent()
			.Match(id)
			.FirstOrDefaultAsync(cancellationToken);
	}

	public async Task<ICollection<PostImage>> GetByIdRangeAsync(
		IEnumerable<PostImageId> ids,
		CancellationToken cancellationToken)
	{
		return await _collection
			.AggregateFluent()
			.Match(ids)
			.ToListAsync(cancellationToken);
	}

	public async Task AddAsync(PostImage entity, CancellationToken cancellationToken)
	{
		await _collection.AddAsync(entity, cancellationToken);
		await _cacheHandler.DeleteResponseAsync(entity.Id.Id, cancellationToken);
	}

	public async Task AddRangeAsync(IEnumerable<PostImage> entities, CancellationToken cancellationToken)
	{
		await _collection.AddRangeAsync(entities, cancellationToken);
		await _cacheHandler.DeleteResponseRangeAsync(entities.Select(p => p.Id.Id), cancellationToken);
	}

	public async Task DeleteAsync(PostImage entity, CancellationToken cancellationToken)
	{
		await _collection.DeleteAsync(entity, cancellationToken);
		await _cacheHandler.DeleteResponseAsync(entity.Id.Id, cancellationToken);
		await _imageCacheHandler.DeleteAsync(entity.Id, cancellationToken);
	}

	public async Task DeleteRangeAsync(IEnumerable<PostImage> entities, CancellationToken cancellationToken)
	{
		await _collection.DeleteRangeAsync(entities, cancellationToken);
		await _cacheHandler.DeleteResponseRangeAsync(entities.Select(p => p.Id.Id), cancellationToken);
		await _imageCacheHandler.DeleteRangeAsync(entities.Select(p => p.Id), cancellationToken);
	}
}
