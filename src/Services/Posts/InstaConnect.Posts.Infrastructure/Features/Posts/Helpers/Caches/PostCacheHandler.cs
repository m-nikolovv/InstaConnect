using InstaConnect.Common.Infrastructure.Features.Caches.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.Posts.Models.Options;
using InstaConnect.Posts.Infrastructure.Features.Posts.Utilities;
using InstaConnect.Posts.Infrastructure.Features.Users.Utilities;

using Microsoft.Extensions.Options;

namespace InstaConnect.Posts.Infrastructure.Features.Posts.Helpers.Caches;

internal class PostCacheHandler : IPostCacheHandler
{
	private readonly ICacheHandler _cacheHandler;
	private readonly PostCacheOptions _cacheOptions;

	public PostCacheHandler(ICacheHandler cacheHandler, IOptions<PostCacheOptions> cacheOptions)
	{
		_cacheHandler = cacheHandler;
		_cacheOptions = cacheOptions.Value;
	}

	public async Task<Post?> GetByIdAsync(PostId id)
	{
		return await _cacheHandler.GetAsync<Post>(PostCacheUtilities.GetByIdKey(id));
	}

	public async Task<PostResponse?> GetByIdAsync(PostId id, CurrentUserQuery currentUser)
	{
		return await _cacheHandler.GetAsync<PostResponse>(PostCacheUtilities.GetResponseByIdKey(id, currentUser));
	}

	public async Task AddAsync(Post entity)
	{
		await _cacheHandler.SetAsync(
			PostCacheUtilities.GetByIdKey(entity.Id),
			entity,
			_cacheOptions.Expirations[PostCacheUtilities.GetByIdKeyPrefix],
			[PostCacheUtilities.GetTag(entity.Id),
			 UserCacheUtilities.GetTag(entity.UserId)]);
	}

	public async Task AddAsync(PostResponse response, CurrentUserQuery currentUser)
	{
		await _cacheHandler.SetAsync(
			PostCacheUtilities.GetResponseByIdKey(response.Id, currentUser),
			response,
			_cacheOptions.Expirations[PostCacheUtilities.GetResponseByIdKeyPrefix],
			[PostCacheUtilities.GetTag(response.Id),
			 UserCacheUtilities.GetTag(response.UserId)]);
	}

	public async Task<bool?> ExistsByIdAsync(PostId id)
	{
		return await _cacheHandler.GetAsync<bool?>(PostCacheUtilities.ExistsByIdKey(id));
	}

	public async Task AddExistsByIdAsync(PostId id, bool exists)
	{
		await _cacheHandler.SetAsync<bool?>(
			PostCacheUtilities.ExistsByIdKey(id),
			exists,
			_cacheOptions.Expirations[PostCacheUtilities.ExistsByIdKeyPrefix],
			[PostCacheUtilities.GetTag(id)]);
	}

	public async Task DeleteAsync(PostId id)
	{
		await _cacheHandler.RemoveByTagAsync(PostCacheUtilities.GetTag(id));
	}

	public async Task DeleteRangeAsync(IEnumerable<PostId> ids)
	{
		await _cacheHandler.RemoveByTagRangeAsync(PostCacheUtilities.GetTagRange(ids));
	}
}
