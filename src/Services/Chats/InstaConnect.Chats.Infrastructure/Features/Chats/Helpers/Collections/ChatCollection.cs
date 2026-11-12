using InstaConnect.Chats.Infrastructure.Features.Chats.Extensions;

namespace InstaConnect.Chats.Infrastructure.Features.Chats.Helpers.Collections;

internal class ChatCollection : IChatCollection
{
	private readonly IChatFluentFactory _fluentFactory;
	private readonly IChatMessageCollection _messageCollection;
	private readonly IMongoDbCollectionHandler<Chat, ChatId> _collectionHandler;

	public ChatCollection(
		IChatFluentFactory fluentFactory,
		IChatMessageCollection messageCollection,
		IMongoDbCollectionHandler<Chat, ChatId> collectionHandler)
	{
		_fluentFactory = fluentFactory;
		_messageCollection = messageCollection;
		_collectionHandler = collectionHandler;
	}

	public IChatFluent AggregateFluent()
	{
		var fluent = _collectionHandler.AggregateWithIgnoreCaseCollation();

		return _fluentFactory.Create(fluent);
	}

	public async Task AddAsync(
		Chat entity,
		CancellationToken cancellationToken)
	{
		await _collectionHandler.InsertAsync(entity, cancellationToken);
	}

	public async Task AddRangeAsync(
		IEnumerable<Chat> entities,
		CancellationToken cancellationToken)
	{
		await _collectionHandler.InsertRangeAsync(entities, cancellationToken);
	}

	public async Task DeleteAsync(
		Chat entity,
		CancellationToken cancellationToken)
	{
		await _messageCollection.DeleteByParentAsync(entity.Id.GetChatMessageByParentFilter(), cancellationToken);
		await _collectionHandler.RemoveAsync(entity.Id.GetFilter(), cancellationToken);
	}

	public async Task DeleteByParentAsync(
		FilterDefinition<Chat> filter,
		CancellationToken cancellationToken)
	{
		var chatIds = await AggregateFluent()
			.Match(filter)
			.GetIdsAsync(cancellationToken);

		await _messageCollection.DeleteByParentAsync(chatIds.GetChatMessageByParentFilter(), cancellationToken);
		await _collectionHandler.RemoveRangeAsync(filter, cancellationToken);
	}
}
