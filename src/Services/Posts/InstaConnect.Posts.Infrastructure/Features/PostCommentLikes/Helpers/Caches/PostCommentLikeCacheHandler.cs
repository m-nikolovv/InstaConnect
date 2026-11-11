using InstaConnect.Common.Infrastructure.Features.Caches.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Models.Options;
using InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Utilities;

using Microsoft.Extensions.Options;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Helpers.Caches;

internal class PostCommentLikeCacheHandler : IPostCommentLikeCacheHandler
{
	private readonly ICacheHandler _cacheHandler;
	private readonly PostCommentLikeCacheOptions _cacheOptions;

	public PostCommentLikeCacheHandler(ICacheHandler cacheHandler, IOptions<PostCommentLikeCacheOptions> cacheOptions)
	{
		_cacheHandler = cacheHandler;
		_cacheOptions = cacheOptions.Value;
	}

	public async Task<PostCommentLike?> GetByIdAsync(PostCommentLikeId id)
	{
		return await _cacheHandler.GetAsync<PostCommentLike>(PostCommentLikeCacheUtilities.GetByIdKey(id));
	}

	public async Task<PostCommentLikeResponse?> GetByIdAsync(PostCommentLikeId id, CurrentUserQuery currentUser)
	{
		return await _cacheHandler.GetAsync<PostCommentLikeResponse>(PostCommentLikeCacheUtilities.GetResponseByIdKey(id, currentUser));
	}

	public async Task AddAsync(PostCommentLike entity)
	{
		await _cacheHandler.SetAsync(PostCommentLikeCacheUtilities.GetByIdKey(entity.Id), entity, _cacheOptions.Expirations[PostCommentLikeCacheUtilities.GetByIdKeyPrefix], PostCommentLikeCacheUtilities.GetTagRange(entity.Id));
	}

	public async Task AddAsync(PostCommentLikeResponse response, CurrentUserQuery currentUser)
	{
		await _cacheHandler.SetAsync(PostCommentLikeCacheUtilities.GetResponseByIdKey(response.Id, currentUser), response, _cacheOptions.Expirations[PostCommentLikeCacheUtilities.GetResponseByIdKeyPrefix], PostCommentLikeCacheUtilities.GetTagRange(response));
	}

	public async Task<bool?> ExistsByIdAsync(PostCommentLikeId id)
	{
		return await _cacheHandler.GetAsync<bool?>(PostCommentLikeCacheUtilities.ExistsByIdKey(id));
	}

	public async Task AddExistsByIdAsync(PostCommentLikeId id, bool exists)
	{
		await _cacheHandler.SetAsync<bool?>(PostCommentLikeCacheUtilities.ExistsByIdKey(id), exists, _cacheOptions.Expirations[PostCommentLikeCacheUtilities.ExistsByIdKeyPrefix], PostCommentLikeCacheUtilities.GetTagRange(id));
	}

	public async Task DeleteAsync(PostCommentLikeId id)
	{
		await _cacheHandler.RemoveByTagAsync(PostCommentLikeCacheUtilities.GetTag(id));
	}

	public async Task DeleteRangeAsync(IEnumerable<PostCommentLikeId> ids)
	{
		await _cacheHandler.RemoveByTagRangeAsync(PostCommentLikeCacheUtilities.GetTagRange(ids));
	}
}
