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

	public async Task<PostLike?> GetByIdAsync(PostLikeId id)
	{
		return await _cacheHandler.GetAsync<PostLike>(PostLikeCacheUtilities.GetByIdKey(id));
	}

	public async Task<PostLikeResponse?> GetByIdAsync(PostLikeId id, CurrentUserQuery currentUser)
	{
		return await _cacheHandler.GetAsync<PostLikeResponse>(PostLikeCacheUtilities.GetResponseByIdKey(id, currentUser));
	}

	public async Task AddAsync(PostLike entity)
	{
		await _cacheHandler.SetAsync(
			PostLikeCacheUtilities.GetByIdKey(entity.Id),
			entity,
			_cacheOptions.Expirations[PostLikeCacheUtilities.GetByIdKeyPrefix],
			[PostLikeCacheUtilities.GetTag(entity.Id),
			 PostCacheUtilities.GetTag(entity.Id.Id),
			 UserCacheUtilities.GetTag(entity.Id.UserId)]);
	}

	public async Task AddAsync(PostLikeResponse response, CurrentUserQuery currentUser)
	{
		List<string> tags =
			[PostLikeCacheUtilities.GetTag(response.Id),
			 PostCacheUtilities.GetTag(response.Id.Id),
			 UserCacheUtilities.GetTag(response.Id.UserId)];

		if (response.Post != null)
		{
			tags.Add(UserCacheUtilities.GetTag(response.Post.UserId));
		}

		await _cacheHandler.SetAsync(
			PostLikeCacheUtilities.GetResponseByIdKey(response.Id, currentUser),
			response,
			_cacheOptions.Expirations[PostLikeCacheUtilities.GetResponseByIdKeyPrefix],
			tags);
	}

	public async Task AddRangeAsync(IEnumerable<PostLike> entities)
	{
		foreach (var entity in entities)
		{
			await AddAsync(entity);
		}
	}

	public async Task<bool?> ExistsByIdAsync(PostLikeId id)
	{
		return await _cacheHandler.GetAsync<bool?>(PostLikeCacheUtilities.ExistsByIdKey(id));
	}

	public async Task AddExistsByIdAsync(PostLikeId id, bool exists)
	{
		await _cacheHandler.SetAsync<bool?>(
			PostLikeCacheUtilities.ExistsByIdKey(id),
			exists,
			_cacheOptions.Expirations[PostLikeCacheUtilities.ExistsByIdKeyPrefix],
			[PostLikeCacheUtilities.GetTag(id),
			 PostCacheUtilities.GetTag(id.Id),
			 UserCacheUtilities.GetTag(id.UserId)]);
	}

	public async Task DeleteAsync(PostLikeId id)
	{
		await _cacheHandler.RemoveByTagAsync(PostLikeCacheUtilities.GetTag(id));
	}

	public async Task DeleteRangeAsync(IEnumerable<PostLikeId> ids)
	{
		await _cacheHandler.RemoveByTagRangeAsync(PostLikeCacheUtilities.GetTagRange(ids));
	}
}
