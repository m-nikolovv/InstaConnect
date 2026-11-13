using InstaConnect.Common.Infrastructure.Features.Caches.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.PostLikes.Models.Options;
using InstaConnect.Posts.Infrastructure.Features.PostLikes.Utilities;
using InstaConnect.Posts.Infrastructure.Features.Posts.Utilities;
using InstaConnect.Posts.Infrastructure.Features.Users.Utilities;

using Microsoft.Extensions.Options;

namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Helpers.Caches;

internal class PostLikeCacheHandler : IPostLikeCacheHandler
{
	private readonly ICacheHandler _cacheHandler;
	private readonly PostLikeCacheOptions _cacheOptions;

	public PostLikeCacheHandler(ICacheHandler cacheHandler, IOptions<PostLikeCacheOptions> cacheOptions)
	{
		_cacheHandler = cacheHandler;
		_cacheOptions = cacheOptions.Value;
	}

	public async Task<PostLike?> GetByIdAsync(PostLikeId id, CancellationToken cancellationToken)
	{
		return await _cacheHandler.GetAsync<PostLike>(PostLikeCacheUtilities.GetByIdKey(id), cancellationToken);
	}

	public async Task<PostLikeResponse?> GetByIdAsync(PostLikeId id, CurrentUserQuery currentUser, CancellationToken cancellationToken)
	{
		return await _cacheHandler.GetAsync<PostLikeResponse>(PostLikeCacheUtilities.GetResponseByIdKey(id, currentUser), cancellationToken);
	}

	public async Task AddAsync(PostLike entity, CancellationToken cancellationToken)
	{
		await _cacheHandler.SetAsync(
			PostLikeCacheUtilities.GetByIdKey(entity.Id),
			entity,
			_cacheOptions.Expirations[PostLikeCacheUtilities.GetByIdKeyPrefix],
			[PostLikeCacheUtilities.GetTag(entity.Id),
			 PostCacheUtilities.GetResponseTag(entity.Id.Id)],
			[PostCacheUtilities.GetTag(entity.Id.Id),
			 UserCacheUtilities.GetTag(entity.Id.UserId)],
			cancellationToken);
	}

	public async Task AddAsync(PostLikeResponse response, CurrentUserQuery currentUser, CancellationToken cancellationToken)
	{
		await _cacheHandler.SetAsync(
			PostLikeCacheUtilities.GetResponseByIdKey(response.Id, currentUser),
			response,
			_cacheOptions.Expirations[PostLikeCacheUtilities.GetResponseByIdKeyPrefix],
			[PostLikeCacheUtilities.GetTag(response.Id),
			 PostCacheUtilities.GetResponseTag(response.Id.Id)],
			[PostCacheUtilities.GetTag(response.Id.Id),
			 UserCacheUtilities.GetTag(response.Id.UserId)],
			cancellationToken);
	}

	public async Task AddRangeAsync(IEnumerable<PostLike> entities, CancellationToken cancellationToken)
	{
		foreach (var entity in entities)
		{
			await AddAsync(entity, cancellationToken);
		}
	}

	public async Task<bool?> ExistsByIdAsync(PostLikeId id, CancellationToken cancellationToken)
	{
		return await _cacheHandler.GetAsync<bool?>(PostLikeCacheUtilities.ExistsByIdKey(id), cancellationToken);
	}

	public async Task AddExistsByIdAsync(PostLikeId id, bool exists, CancellationToken cancellationToken)
	{
		await _cacheHandler.SetAsync<bool?>(
			PostLikeCacheUtilities.ExistsByIdKey(id),
			exists,
			_cacheOptions.Expirations[PostLikeCacheUtilities.ExistsByIdKeyPrefix],
			[PostLikeCacheUtilities.GetTag(id)],
			[PostCacheUtilities.GetTag(id.Id),
			 UserCacheUtilities.GetTag(id.UserId)],
			cancellationToken);
	}

	public async Task DeleteAsync(PostLikeId id, CancellationToken cancellationToken)
	{
		await _cacheHandler.RemoveByTagAsync(PostLikeCacheUtilities.GetTag(id), cancellationToken);
	}

	public async Task DeleteRangeAsync(IEnumerable<PostLikeId> ids, CancellationToken cancellationToken)
	{
		await _cacheHandler.RemoveByTagRangeAsync(PostLikeCacheUtilities.GetTagRange(ids), cancellationToken);
	}
}
