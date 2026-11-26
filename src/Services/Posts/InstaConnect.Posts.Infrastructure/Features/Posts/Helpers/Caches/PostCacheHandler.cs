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

	public async Task<PostResponse?> GetByIdAsync(PostId id, UserId currentUserId, CancellationToken cancellationToken)
	{
		return await _cacheHandler.GetAsync<PostResponse>(PostCacheUtilities.GetResponseByIdKey(id, currentUserId), cancellationToken);
	}

	public async Task AddAsync(PostResponse response, UserId currentUserId, CancellationToken cancellationToken)
	{
		await _cacheHandler.SetAsync(
			PostCacheUtilities.GetResponseByIdKey(response.Id, currentUserId),
			response,
			_cacheOptions.Expirations[PostCacheUtilities.GetResponseByIdKeyPrefix],
			[PostCacheUtilities.GetTag(response.Id),
			 PostCacheUtilities.GetResponseTag(response.Id)],
			[UserCacheUtilities.GetTag(response.UserId)],
			cancellationToken);
	}

	public async Task AddRangeAsync(IEnumerable<PostResponse> responses, UserId currentUserId, CancellationToken cancellationToken)
	{
		foreach (var response in responses)
		{
			await AddAsync(response, currentUserId, cancellationToken);
		}
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
