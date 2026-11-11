using InstaConnect.Chats.Infrastructure.Features.ChatMessageImages.Abstractions;
using InstaConnect.Chats.Infrastructure.Features.ChatMessageImages.Extensions;

namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Helpers.Collections;

internal class ChatMessageCollection : MongoDbCollection<ChatMessage, ChatMessageId>, IChatMessageCollection
{
	private readonly IChatCacheHandler _cacheHandler;
	private readonly IChatMessageFluentFactory _fluentFactory;
	private readonly IChatMessageCacheHandler _messageCacheHandler;
	private readonly IChatMessageImageCollection _messageImageCollection;

	public ChatMessageCollection(
		ISessionHandler sessionHandler,
		IChatCacheHandler cacheHandler,
		IChatMessageFluentFactory fluentFactory,
		IMongoCollection<ChatMessage> collection,
		IChatMessageCacheHandler messageCacheHandler,
		IChatMessageImageCollection messageImageCollection) : base(sessionHandler, collection)
	{
		_cacheHandler = cacheHandler;
		_fluentFactory = fluentFactory;
		_messageCacheHandler = messageCacheHandler;
		_messageImageCollection = messageImageCollection;
	}

	public IChatMessageFluent AggregateFluent()
	{
		var fluent = AggregateWithIgnoreCaseCollation();

		return _fluentFactory.Create(fluent);
	}

	public async Task AddAsync(
		ChatMessage entity,
		CancellationToken cancellationToken)
	{
		await _messageImageCollection.AddByParentAsync(entity.Id.GetChatMessageImageByParentFilter(), cancellationToken);
		await InsertAsync(entity, cancellationToken);
		await _cacheHandler.DeleteResponseAsync(entity.Id.Id);
		await _messageCacheHandler.DeleteAsync(entity.Id);
	}

	public async Task AddByParentAsync(
		FilterDefinition<ChatMessage> filter,
		CancellationToken cancellationToken)
	{
		var messageIds = await GetIdsAsync(filter, cancellationToken);

		await _messageImageCollection.AddByParentAsync(messageIds.GetChatMessageImageByParentFilter(), cancellationToken);
		await _cacheHandler.DeleteResponseRangeAsync(messageIds.Select(p => p.Id));
		await _messageCacheHandler.DeleteRangeAsync(messageIds);
	}

	public async Task AddRangeAsync(
		IEnumerable<ChatMessage> entities,
		CancellationToken cancellationToken)
	{
		await _messageImageCollection.AddByParentAsync(entities.Select(p => p.Id).GetChatMessageImageByParentFilter(), cancellationToken);
		await InsertRangeAsync(entities, cancellationToken);
		await _cacheHandler.DeleteResponseRangeAsync(entities.Select(p => p.Id.Id));
		await _messageCacheHandler.DeleteRangeAsync(entities.Select(p => p.Id));
	}

	public async Task UpdateAsync(
		ChatMessage entity,
		CancellationToken cancellationToken)
	{
		await _messageImageCollection.UpdateByParentAsync(entity.Id.GetChatMessageImageByParentFilter(), cancellationToken);
		await ReplaceAsync(entity.Id.GetFilter(), entity, cancellationToken);
		await _messageCacheHandler.DeleteAsync(entity.Id);
	}

	public async Task UpdateByParentAsync(
		FilterDefinition<ChatMessage> filter,
		CancellationToken cancellationToken)
	{
		var messageIds = await GetIdsAsync(filter, cancellationToken);

		await _messageImageCollection.UpdateByParentAsync(messageIds.GetChatMessageImageByParentFilter(), cancellationToken);
		await _messageCacheHandler.DeleteRangeAsync(messageIds);
	}

	public async Task DeleteAsync(
		ChatMessage entity,
		CancellationToken cancellationToken)
	{
		await _messageImageCollection.DeleteByParentAsync(entity.Id.GetChatMessageImageByParentFilter(), cancellationToken);
		await RemoveAsync(entity.Id.GetFilter(), cancellationToken);
		await _cacheHandler.DeleteResponseAsync(entity.Id.Id);
		await _messageCacheHandler.DeleteAsync(entity.Id);
	}

	public async Task DeleteByParentAsync(
		FilterDefinition<ChatMessage> filter,
		CancellationToken cancellationToken)
	{
		var messageIds = await GetIdsAsync(filter, cancellationToken);

		await _messageImageCollection.DeleteByParentAsync(messageIds.GetChatMessageImageByParentFilter(), cancellationToken);
		await RemoveRangeAsync(filter, cancellationToken);
		await _cacheHandler.DeleteResponseRangeAsync(messageIds.Select(p => p.Id));
		await _messageCacheHandler.DeleteRangeAsync(messageIds);
	}
}
