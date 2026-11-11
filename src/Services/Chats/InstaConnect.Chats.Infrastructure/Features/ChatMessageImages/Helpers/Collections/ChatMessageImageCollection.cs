using InstaConnect.Chats.Infrastructure.Features.ChatMessageImages.Abstractions;
using InstaConnect.Chats.Infrastructure.Features.ChatMessageImages.Extensions;

namespace InstaConnect.Chats.Infrastructure.Features.ChatMessageImages.Helpers.Collections;

internal class ChatMessageImageCollection : MongoDbCollection<ChatMessageImage, ChatMessageImageId>, IChatMessageImageCollection
{
	private readonly IChatMessageCacheHandler _messageCacheHandler;
	private readonly IChatMessageImageFluentFactory _fluentFactory;
	private readonly IChatMessageImageCacheHandler _messageImageCacheHandler;

	public ChatMessageImageCollection(
		ISessionHandler sessionHandler,
		IChatMessageCacheHandler messageCacheHandler,
		IChatMessageImageFluentFactory fluentFactory,
		IMongoCollection<ChatMessageImage> collection,
		IChatMessageImageCacheHandler messageImageCacheHandler) : base(sessionHandler, collection)
	{
		_fluentFactory = fluentFactory;
		_messageCacheHandler = messageCacheHandler;
		_messageImageCacheHandler = messageImageCacheHandler;
	}

	public IChatMessageImageFluent AggregateFluent()
	{
		var fluent = AggregateWithIgnoreCaseCollation();

		return _fluentFactory.Create(fluent);
	}

	public async Task AddAsync(
		ChatMessageImage entity,
		CancellationToken cancellationToken)
	{
		await InsertAsync(entity, cancellationToken);
		await _messageCacheHandler.DeleteResponseAsync(entity.Id.Id);
		await _messageImageCacheHandler.DeleteAsync(entity.Id);
	}

	public async Task AddByParentAsync(
		FilterDefinition<ChatMessageImage> filter,
		CancellationToken cancellationToken)
	{
		var imageIds = await GetIdsAsync(filter, cancellationToken);

		await _messageCacheHandler.DeleteResponseRangeAsync(imageIds.Select(p => p.Id));
		await _messageImageCacheHandler.DeleteRangeAsync(imageIds);
	}

	public async Task AddRangeAsync(
		IEnumerable<ChatMessageImage> entities,
		CancellationToken cancellationToken)
	{
		await InsertRangeAsync(entities, cancellationToken);
		await _messageCacheHandler.DeleteResponseRangeAsync(entities.Select(p => p.Id.Id));
		await _messageImageCacheHandler.DeleteRangeAsync(entities.Select(p => p.Id));
	}

	public async Task UpdateByParentAsync(
		FilterDefinition<ChatMessageImage> filter,
		CancellationToken cancellationToken)
	{
		var imageIds = await GetIdsAsync(filter, cancellationToken);

		await _messageImageCacheHandler.DeleteRangeAsync(imageIds);
	}

	public async Task DeleteAsync(
		ChatMessageImage entity,
		CancellationToken cancellationToken)
	{
		await RemoveAsync(entity.Id.GetFilter(), cancellationToken);
		await _messageCacheHandler.DeleteResponseAsync(entity.Id.Id);
		await _messageImageCacheHandler.DeleteAsync(entity.Id);
	}

	public async Task DeleteByParentAsync(
		FilterDefinition<ChatMessageImage> filter,
		CancellationToken cancellationToken)
	{
		var imageIds = await GetIdsAsync(filter, cancellationToken);

		await RemoveRangeAsync(filter, cancellationToken);
		await _messageCacheHandler.DeleteResponseRangeAsync(imageIds.Select(p => p.Id));
		await _messageImageCacheHandler.DeleteRangeAsync(imageIds);
	}

	public async Task DeleteRangeAsync(
		IEnumerable<ChatMessageImage> entities,
		CancellationToken cancellationToken)
	{
		await RemoveRangeAsync(entities.Select(p => p.Id).GetFilter(), cancellationToken);
		await _messageCacheHandler.DeleteResponseRangeAsync(entities.Select(p => p.Id.Id));
		await _messageImageCacheHandler.DeleteRangeAsync(entities.Select(p => p.Id));
	}
}
