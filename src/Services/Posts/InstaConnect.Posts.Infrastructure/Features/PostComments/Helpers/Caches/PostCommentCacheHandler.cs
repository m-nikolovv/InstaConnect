using InstaConnect.Common.Infrastructure.Features.Caches.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.PostComments.Models.Options;
using InstaConnect.Posts.Infrastructure.Features.PostComments.Utilities;
using InstaConnect.Posts.Infrastructure.Features.Posts.Utilities;
using InstaConnect.Posts.Infrastructure.Features.Users.Utilities;

namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Helpers.Caches;

internal class PostCommentCacheHandler : IPostCommentCacheHandler
{
	private readonly ICacheHandler _cacheHandler;
	private readonly PostCommentCacheOptions _cacheOptions;

	public PostCommentCacheHandler(ICacheHandler cacheHandler, PostCommentCacheOptions cacheOptions)
	{
		_cacheHandler = cacheHandler;
		_cacheOptions = cacheOptions;
	}

	public async Task<PostCommentResponse?> GetByIdAsync(PostCommentId id, UserId currentUserId, CancellationToken cancellationToken)
	{
		return await _cacheHandler.GetAsync<PostCommentResponse>(PostCommentCacheUtilities.GetResponseByIdKey(id, currentUserId), cancellationToken);
	}

	public async Task AddAsync(PostCommentResponse response, UserId currentUserId, CancellationToken cancellationToken)
	{
		await _cacheHandler.SetAsync(
			PostCommentCacheUtilities.GetResponseByIdKey(response.Id, currentUserId),
			response,
			_cacheOptions.Expirations[PostCommentCacheUtilities.GetResponseByIdKeyPrefix],
			[PostCommentCacheUtilities.GetTag(response.Id),
			 PostCommentCacheUtilities.GetResponseTag(response.Id),
			 PostCacheUtilities.GetResponseTag(response.Id.Id)],
			[PostCacheUtilities.GetTag(response.Id.Id),
			 UserCacheUtilities.GetTag(response.UserId)],
			cancellationToken);
	}

	public async Task AddRangeAsync(IEnumerable<PostCommentResponse> responses, UserId currentUserId, CancellationToken cancellationToken)
	{
		foreach (var response in responses)
		{
			await AddAsync(response, currentUserId, cancellationToken);
		}
	}

	public async Task DeleteAsync(PostCommentId id, CancellationToken cancellationToken)
	{
		await _cacheHandler.RemoveByTagAsync(PostCommentCacheUtilities.GetTag(id), cancellationToken);
	}

	public async Task DeleteRangeAsync(IEnumerable<PostCommentId> ids, CancellationToken cancellationToken)
	{
		await _cacheHandler.RemoveByTagRangeAsync(PostCommentCacheUtilities.GetTagRange(ids), cancellationToken);
	}

	public async Task DeleteResponseAsync(PostCommentId id, CancellationToken cancellationToken)
	{
		await _cacheHandler.RemoveByTagAsync(PostCommentCacheUtilities.GetResponseTag(id), cancellationToken);
	}

	public async Task DeleteResponseRangeAsync(IEnumerable<PostCommentId> ids, CancellationToken cancellationToken)
	{
		await _cacheHandler.RemoveByTagRangeAsync(PostCommentCacheUtilities.GetResponseTagRange(ids), cancellationToken);
	}
}
