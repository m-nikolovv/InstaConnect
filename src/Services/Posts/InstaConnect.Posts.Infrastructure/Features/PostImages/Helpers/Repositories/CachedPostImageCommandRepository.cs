using InstaConnect.Posts.Domain.Features.PostImages.Abstractions;
using InstaConnect.Posts.Domain.Features.PostImages.Models.ValueObjects;
using InstaConnect.Posts.Infrastructure.Features.PostImages.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Features.PostImages.Helpers.Repositories;

internal class CachedPostImageCommandRepository : IPostImageCommandRepository
{
	private readonly IPostCacheHandler _cacheHandler;
	private readonly IPostImageCommandRepository _repository;
	private readonly IPostImageCacheHandler _imageCacheHandler;

	public CachedPostImageCommandRepository(
		IPostCacheHandler cacheHandler,
		IPostImageCommandRepository repository,
		IPostImageCacheHandler imageCacheHandler)
	{
		_repository = repository;
		_cacheHandler = cacheHandler;
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

		var entity = await _repository.GetByIdAsync(id, cancellationToken);

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
		return await _repository.GetByIdRangeAsync(ids, cancellationToken);
	}

	public async Task AddAsync(PostImage entity, CancellationToken cancellationToken)
	{
		await _repository.AddAsync(entity, cancellationToken);
		await _cacheHandler.DeleteAsync(entity.Id.Id);
		await _imageCacheHandler.DeleteAsync(entity.Id);
	}

	public async Task AddRangeAsync(IEnumerable<PostImage> entities, CancellationToken cancellationToken)
	{
		await _repository.AddRangeAsync(entities, cancellationToken);
		await _cacheHandler.DeleteRangeAsync(entities.Select(p => p.Id.Id));
		await _imageCacheHandler.DeleteRangeAsync(entities.Select(p => p.Id));
	}

	public async Task DeleteAsync(PostImage entity, CancellationToken cancellationToken)
	{
		await _repository.DeleteAsync(entity, cancellationToken);
		await _cacheHandler.DeleteAsync(entity.Id.Id);
		await _imageCacheHandler.DeleteAsync(entity.Id);
	}

	public async Task DeleteRangeAsync(IEnumerable<PostImage> entities, CancellationToken cancellationToken)
	{
		await _repository.DeleteRangeAsync(entities, cancellationToken);
		await _cacheHandler.DeleteRangeAsync(entities.Select(p => p.Id.Id));
		await _imageCacheHandler.DeleteRangeAsync(entities.Select(p => p.Id));
	}
}
