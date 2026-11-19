using InstaConnect.Common.Infrastructure.Features.Caches.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Models.Options;
using InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Infrastructure.Features.PostComments.Utilities;
using InstaConnect.Posts.Infrastructure.Features.Posts.Utilities;
using InstaConnect.Posts.Infrastructure.Features.Users.Utilities;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Helpers.Caches;

internal class PostCommentLikeCacheHandler : IPostCommentLikeCacheHandler
{
	private readonly ICacheHandler _cacheHandler;
	private readonly PostCommentLikeCacheOptions _cacheOptions;

	public PostCommentLikeCacheHandler(ICacheHandler cacheHandler, PostCommentLikeCacheOptions cacheOptions)
	{
		_cacheHandler = cacheHandler;
		_cacheOptions = cacheOptions;
	}

	public async Task<PostCommentLikeResponse?> GetByIdAsync(PostCommentLikeId id, UserId currentUserId, CancellationToken cancellationToken)
	{
		return await _cacheHandler.GetAsync<PostCommentLikeResponse>(PostCommentLikeCacheUtilities.GetResponseByIdKey(id, currentUserId), cancellationToken);
	}

	public async Task AddAsync(PostCommentLikeResponse response, UserId currentUserId, CancellationToken cancellationToken)
	{
		await _cacheHandler.SetAsync(
			PostCommentLikeCacheUtilities.GetResponseByIdKey(response.Id, currentUserId),
			response,
			_cacheOptions.Expirations[PostCommentLikeCacheUtilities.GetResponseByIdKeyPrefix],
			[PostCommentLikeCacheUtilities.GetTag(response.Id),
			 PostCommentCacheUtilities.GetResponseTag(response.Id.CommentId),
			 PostCacheUtilities.GetResponseTag(response.Id.CommentId.Id)],
			[PostCommentCacheUtilities.GetTag(response.Id.CommentId),
			 UserCacheUtilities.GetTag(response.Id.UserId)],
			cancellationToken);
	}

	public async Task AddRangeAsync(IEnumerable<PostCommentLikeResponse> responses, UserId currentUserId, CancellationToken cancellationToken)
	{
		foreach (var response in responses)
		{
			await AddAsync(response, currentUserId, cancellationToken);
		}
	}

	public async Task DeleteAsync(PostCommentLikeId id, CancellationToken cancellationToken)
	{
		await _cacheHandler.RemoveByTagAsync(PostCommentLikeCacheUtilities.GetTag(id), cancellationToken);
	}

	public async Task DeleteRangeAsync(IEnumerable<PostCommentLikeId> ids, CancellationToken cancellationToken)
	{
		await _cacheHandler.RemoveByTagRangeAsync(PostCommentLikeCacheUtilities.GetTagRange(ids), cancellationToken);
	}
}
