using InstaConnect.Common.Infrastructure.Features.Caches.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.PostComments.Models.Options;
using InstaConnect.Posts.Infrastructure.Features.PostComments.Utilities;

using Microsoft.Extensions.Options;

namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Helpers.Caches;

internal class PostCommentCacheHandler : IPostCommentCacheHandler
{
	private readonly ICacheHandler _cacheHandler;
	private readonly PostCommentCacheOptions _cacheOptions;

	public PostCommentCacheHandler(ICacheHandler cacheHandler, IOptions<PostCommentCacheOptions> cacheOptions)
	{
		_cacheHandler = cacheHandler;
		_cacheOptions = cacheOptions.Value;
	}

	public async Task<PostComment?> GetByIdAsync(PostCommentId id)
	{
		return await _cacheHandler.GetAsync<PostComment>(PostCommentCacheUtilities.GetByIdKey(id));
	}

	public async Task<PostCommentResponse?> GetByIdAsync(PostCommentId id, CurrentUserQuery currentUser)
	{
		return await _cacheHandler.GetAsync<PostCommentResponse>(PostCommentCacheUtilities.GetResponseByIdKey(id, currentUser));
	}

	public async Task AddAsync(PostComment entity)
	{
		await _cacheHandler.SetAsync(PostCommentCacheUtilities.GetByIdKey(entity.Id), entity, _cacheOptions.Expirations[PostCommentCacheUtilities.GetByIdKeyPrefix], PostCommentCacheUtilities.GetTagRange(entity));
	}

	public async Task AddAsync(PostCommentResponse response, CurrentUserQuery currentUser)
	{
		await _cacheHandler.SetAsync(PostCommentCacheUtilities.GetResponseByIdKey(response.Id, currentUser), response, _cacheOptions.Expirations[PostCommentCacheUtilities.GetResponseByIdKeyPrefix], PostCommentCacheUtilities.GetTagRange(response));
	}

	public async Task<bool?> ExistsByIdAsync(PostCommentId id)
	{
		return await _cacheHandler.GetAsync<bool?>(PostCommentCacheUtilities.ExistsByIdKey(id));
	}

	public async Task AddExistsByIdAsync(PostCommentId id, bool exists)
	{
		await _cacheHandler.SetAsync<bool?>(PostCommentCacheUtilities.ExistsByIdKey(id), exists, _cacheOptions.Expirations[PostCommentCacheUtilities.ExistsByIdKeyPrefix], PostCommentCacheUtilities.GetTagRange(id));
	}

	public async Task DeleteAsync(PostCommentId id)
	{
		await _cacheHandler.RemoveByTagAsync(PostCommentCacheUtilities.GetTag(id));
	}

	public async Task DeleteRangeAsync(IEnumerable<PostCommentId> ids)
	{
		await _cacheHandler.RemoveByTagRangeAsync(PostCommentCacheUtilities.GetTagRange(ids));
	}
}
