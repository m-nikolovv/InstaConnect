using InstaConnect.Common.Infrastructure.Features.Caches.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.PostLikes.Models.Options;
using InstaConnect.Posts.Infrastructure.Features.PostLikes.Utilities;
using InstaConnect.Posts.Infrastructure.Features.Posts.Utilities;
using InstaConnect.Posts.Infrastructure.Features.Users.Utilities;

namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Helpers.Caches;

internal class PostLikeCacheHandler : IPostLikeCacheHandler
{
	private readonly ICacheHandler _cacheHandler;
	private readonly PostLikeCacheOptions _cacheOptions;

	public PostLikeCacheHandler(ICacheHandler cacheHandler, PostLikeCacheOptions cacheOptions)
	{
		_cacheHandler = cacheHandler;
		_cacheOptions = cacheOptions;
	}

	public async Task<PostLikeResponse?> GetByIdAsync(PostLikeId id, UserId currentUserId, CancellationToken cancellationToken)
	{
		return await _cacheHandler.GetAsync<PostLikeResponse>(PostLikeCacheUtilities.GetResponseByIdKey(id, currentUserId), cancellationToken);
	}

	public async Task AddAsync(PostLikeResponse response, UserId currentUserId, CancellationToken cancellationToken)
	{
		await _cacheHandler.SetAsync(
			PostLikeCacheUtilities.GetResponseByIdKey(response.Id, currentUserId),
			response,
			_cacheOptions.Expirations[PostLikeCacheUtilities.GetResponseByIdKeyPrefix],
			[PostLikeCacheUtilities.GetTag(response.Id),
			 PostCacheUtilities.GetResponseTag(response.Id.Id)],
			[PostCacheUtilities.GetTag(response.Id.Id),
			 UserCacheUtilities.GetTag(response.Id.UserId)],
			cancellationToken);
	}

	public async Task AddRangeAsync(IEnumerable<PostLikeResponse> responses, UserId currentUserId, CancellationToken cancellationToken)
	{
		foreach (var response in responses)
		{
			await AddAsync(response, currentUserId, cancellationToken);
		}
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
