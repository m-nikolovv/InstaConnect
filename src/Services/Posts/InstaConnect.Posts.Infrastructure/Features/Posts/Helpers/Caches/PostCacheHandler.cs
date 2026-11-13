using InstaConnect.Common.Infrastructure.Features.Caches.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.Posts.Models.Options;
using InstaConnect.Posts.Infrastructure.Features.Posts.Utilities;
using InstaConnect.Posts.Infrastructure.Features.Users.Utilities;

namespace InstaConnect.Posts.Infrastructure.Features.Posts.Helpers.Caches;

internal class PostCacheHandler : IPostCacheHandler
{
	private readonly ICacheHandler _cacheHandler;
	private readonly PostCacheOptions _cacheOptions;

	public PostCacheHandler(ICacheHandler cacheHandler, PostCacheOptions cacheOptions)
	{
		_cacheHandler = cacheHandler;
		_cacheOptions = cacheOptions;
	}

	public async Task<Post?> GetByIdAsync(PostId id, CancellationToken cancellationToken)
	{
		return await _cacheHandler.GetAsync<Post>(PostCacheUtilities.GetByIdKey(id), cancellationToken);
	}

	public async Task<PostResponse?> GetByIdAsync(PostId id, CurrentUserQuery currentUser, CancellationToken cancellationToken)
	{
		return await _cacheHandler.GetAsync<PostResponse>(PostCacheUtilities.GetResponseByIdKey(id, currentUser), cancellationToken);
	}

	public async Task AddAsync(Post entity, CancellationToken cancellationToken)
	{
		await _cacheHandler.SetAsync(
			PostCacheUtilities.GetByIdKey(entity.Id),
			entity,
			_cacheOptions.Expirations[PostCacheUtilities.GetByIdKeyPrefix],
			[PostCacheUtilities.GetTag(entity.Id)],
			[UserCacheUtilities.GetTag(entity.UserId)],
			cancellationToken);
	}

	public async Task AddAsync(PostResponse response, CurrentUserQuery currentUser, CancellationToken cancellationToken)
	{
		await _cacheHandler.SetAsync(
			PostCacheUtilities.GetResponseByIdKey(response.Id, currentUser),
			response,
			_cacheOptions.Expirations[PostCacheUtilities.GetResponseByIdKeyPrefix],
			[PostCacheUtilities.GetTag(response.Id),
			 PostCacheUtilities.GetResponseTag(response.Id)],
			[UserCacheUtilities.GetTag(response.UserId)],
			cancellationToken);
	}

	public async Task AddRangeAsync(IEnumerable<Post> entities, CancellationToken cancellationToken)
	{
		foreach (var entity in entities)
		{
			await AddAsync(entity, cancellationToken);
		}
	}

	public async Task<bool?> ExistsByIdAsync(PostId id, CancellationToken cancellationToken)
	{
		return await _cacheHandler.GetAsync<bool?>(PostCacheUtilities.ExistsByIdKey(id), cancellationToken);
	}

	public async Task AddExistsByIdAsync(PostId id, bool exists, CancellationToken cancellationToken)
	{
		await _cacheHandler.SetAsync<bool?>(
			PostCacheUtilities.ExistsByIdKey(id),
			exists,
			_cacheOptions.Expirations[PostCacheUtilities.ExistsByIdKeyPrefix],
			[PostCacheUtilities.GetTag(id)],
			cancellationToken);
	}

	public async Task DeleteAsync(PostId id, CancellationToken cancellationToken)
	{
		await _cacheHandler.RemoveByTagAsync(PostCacheUtilities.GetTag(id), cancellationToken);
	}

	public async Task DeleteRangeAsync(IEnumerable<PostId> ids, CancellationToken cancellationToken)
	{
		await _cacheHandler.RemoveByTagRangeAsync(PostCacheUtilities.GetTagRange(ids), cancellationToken);
	}

	public async Task DeleteResponseAsync(PostId id, CancellationToken cancellationToken)
	{
		await _cacheHandler.RemoveByTagAsync(PostCacheUtilities.GetResponseTag(id), cancellationToken);
	}

	public async Task DeleteResponseRangeAsync(IEnumerable<PostId> ids, CancellationToken cancellationToken)
	{
		await _cacheHandler.RemoveByTagRangeAsync(PostCacheUtilities.GetResponseTagRange(ids), cancellationToken);
	}
}
