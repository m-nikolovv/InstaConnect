using InstaConnect.Chats.Infrastructure.Features.ChatMessageImages.Abstractions;
using InstaConnect.Chats.Infrastructure.Features.ChatMessageImages.Extensions;

namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Helpers.Collections;

internal class ChatMessageCollection : IChatMessageCollection
{
	private readonly IChatMessageFluentFactory _fluentFactory;
	private readonly IChatMessageImageCollection _messageImageCollection;
	private readonly IMongoDbCollectionHandler<ChatMessage, ChatMessageId> _collectionHandler;

	public ChatMessageCollection(
		IChatMessageFluentFactory fluentFactory,
		IChatMessageImageCollection messageImageCollection,
		IMongoDbCollectionHandler<ChatMessage, ChatMessageId> collectionHandler)
	{
		_fluentFactory = fluentFactory;
		_collectionHandler = collectionHandler;
		_messageImageCollection = messageImageCollection;
	}

	public IChatMessageFluent AggregateFluent()
	{
		var fluent = _collectionHandler.AggregateWithIgnoreCaseCollation();

		return _fluentFactory.Create(fluent);
	}

	public async Task AddAsync(
		ChatMessage entity,
		CancellationToken cancellationToken)
	{
		await _collectionHandler.InsertAsync(entity, cancellationToken);
	}

	public async Task AddRangeAsync(
		IEnumerable<ChatMessage> entities,
		CancellationToken cancellationToken)
	{
		await _collectionHandler.InsertRangeAsync(entities, cancellationToken);
	}

	public async Task UpdateAsync(
		ChatMessage entity,
		CancellationToken cancellationToken)
	{
		await _collectionHandler.ReplaceAsync(entity.Id.GetFilter(), entity, cancellationToken);
	}

	public async Task DeleteAsync(
		ChatMessage entity,
		CancellationToken cancellationToken)
	{
		await _messageImageCollection.DeleteByParentAsync(entity.Id.GetChatMessageImageByParentFilter(), cancellationToken);
		await _collectionHandler.RemoveAsync(entity.Id.GetFilter(), cancellationToken);
	}

	public async Task DeleteByParentAsync(
		FilterDefinition<ChatMessage> filter,
		CancellationToken cancellationToken)
	{
		var messageIds = await AggregateFluent()
			.Match(filter)
			.GetIdsAsync(cancellationToken);

		await _messageImageCollection.DeleteByParentAsync(messageIds.GetChatMessageImageByParentFilter(), cancellationToken);
		await _collectionHandler.RemoveRangeAsync(filter, cancellationToken);
	}
}
