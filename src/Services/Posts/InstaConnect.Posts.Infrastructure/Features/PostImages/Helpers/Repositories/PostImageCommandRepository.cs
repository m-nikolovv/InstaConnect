using InstaConnect.Posts.Domain.Features.PostImages.Abstractions;
using InstaConnect.Posts.Domain.Features.PostImages.Models.ValueObjects;
using InstaConnect.Posts.Infrastructure.Features.PostImages.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Features.PostImages.Helpers.Repositories;

internal class PostImageCommandRepository : IPostImageCommandRepository
{
	private readonly IPostImageCollection _collection;
	private readonly IPostImageCacheHandler _imageCacheHandler;

	public PostImageCommandRepository(
		IPostImageCollection collection,
		IPostImageCacheHandler imageCacheHandler)
	{
		_collection = collection;
		_imageCacheHandler = imageCacheHandler;
	}

	public async Task<PostImage?> GetByIdAsync(
		PostImageId id,
		CancellationToken cancellationToken)
	{
		var cachedEntity = await _imageCacheHandler.GetByIdAsync(id);

		if (cachedEntity != null)
		{
			return cachedEntity;
		}

		var entity = await _collection
			.AggregateFluent()
			.Match(id)
			.FirstOrDefaultAsync(cancellationToken);

		if (entity != null)
		{
			await _imageCacheHandler.AddAsync(entity);
		}

		return entity;
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
	}

	public async Task AddRangeAsync(IEnumerable<PostImage> entities, CancellationToken cancellationToken)
	{
		await _collection.AddRangeAsync(entities, cancellationToken);
	}

	public async Task DeleteAsync(PostImage entity, CancellationToken cancellationToken)
	{
		await _collection.DeleteAsync(entity, cancellationToken);
	}

	public async Task DeleteRangeAsync(IEnumerable<PostImage> entities, CancellationToken cancellationToken)
	{
		await _collection.DeleteRangeAsync(entities, cancellationToken);
	}
}
