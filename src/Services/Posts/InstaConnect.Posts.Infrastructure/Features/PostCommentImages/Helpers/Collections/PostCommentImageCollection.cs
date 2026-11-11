using InstaConnect.Posts.Domain.Features.PostCommentImages.Models.ValueObjects;
using InstaConnect.Posts.Infrastructure.Features.PostCommentImages.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.PostCommentImages.Extensions;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentImages.Helpers.Collections;

internal class PostCommentImageCollection : MongoDbCollection<PostCommentImage, PostCommentImageId>, IPostCommentImageCollection
{
	private readonly IPostCommentCacheHandler _commentCacheHandler;
	private readonly IPostCommentImageFluentFactory _fluentFactory;
	private readonly IPostCommentImageCacheHandler _commentImageCacheHandler;

	public PostCommentImageCollection(
		ISessionHandler sessionHandler,
		IPostCommentCacheHandler commentCacheHandler,
		IPostCommentImageFluentFactory fluentFactory,
		IMongoCollection<PostCommentImage> collection,
		IPostCommentImageCacheHandler commentImageCacheHandler) : base(sessionHandler, collection)
	{
		_fluentFactory = fluentFactory;
		_commentCacheHandler = commentCacheHandler;
		_commentImageCacheHandler = commentImageCacheHandler;
	}

	public IPostCommentImageFluent AggregateFluent()
	{
		var fluent = AggregateWithIgnoreCaseCollation();

		return _fluentFactory.Create(fluent);
	}

	public async Task AddAsync(
		PostCommentImage entity,
		CancellationToken cancellationToken)
	{
		await InsertAsync(entity, cancellationToken);
		await _commentCacheHandler.DeleteResponseAsync(entity.Id.Id);
		await _commentImageCacheHandler.DeleteAsync(entity.Id);
	}

	public async Task CascadeAddAsync(
		FilterDefinition<PostCommentImage> filter,
		CancellationToken cancellationToken)
	{
		var imageIds = await GetIdsAsync(filter, cancellationToken);

		await _commentCacheHandler.DeleteResponseRangeAsync(imageIds.Select(p => p.Id));
		await _commentImageCacheHandler.DeleteRangeAsync(imageIds);
	}

	public async Task AddRangeAsync(
		IEnumerable<PostCommentImage> entities,
		CancellationToken cancellationToken)
	{
		await InsertRangeAsync(entities, cancellationToken);
		await _commentCacheHandler.DeleteResponseRangeAsync(entities.Select(p => p.Id.Id));
		await _commentImageCacheHandler.DeleteRangeAsync(entities.Select(p => p.Id));
	}

	public async Task CascadeUpdateAsync(
		FilterDefinition<PostCommentImage> filter,
		CancellationToken cancellationToken)
	{
		var imageIds = await GetIdsAsync(filter, cancellationToken);

		await _commentImageCacheHandler.DeleteRangeAsync(imageIds);
	}

	public async Task DeleteAsync(
		PostCommentImage entity,
		CancellationToken cancellationToken)
	{
		await RemoveAsync(entity.Id.GetFilter(), cancellationToken);
		await _commentCacheHandler.DeleteResponseAsync(entity.Id.Id);
		await _commentImageCacheHandler.DeleteAsync(entity.Id);
	}

	public async Task CascadeDeleteAsync(
		FilterDefinition<PostCommentImage> filter,
		CancellationToken cancellationToken)
	{
		var imageIds = await GetIdsAsync(filter, cancellationToken);

		await RemoveRangeAsync(filter, cancellationToken);
		await _commentCacheHandler.DeleteResponseRangeAsync(imageIds.Select(p => p.Id));
		await _commentImageCacheHandler.DeleteRangeAsync(imageIds);
	}

	public async Task DeleteRangeAsync(
		IEnumerable<PostCommentImage> entities,
		CancellationToken cancellationToken)
	{
		await RemoveRangeAsync(entities.Select(p => p.Id).GetFilter(), cancellationToken);
		await _commentCacheHandler.DeleteResponseRangeAsync(entities.Select(p => p.Id.Id));
		await _commentImageCacheHandler.DeleteRangeAsync(entities.Select(p => p.Id));
	}
}
