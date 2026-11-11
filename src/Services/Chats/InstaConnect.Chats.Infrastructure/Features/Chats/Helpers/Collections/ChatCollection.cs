using InstaConnect.Chats.Infrastructure.Features.Chats.Extensions;

namespace InstaConnect.Chats.Infrastructure.Features.Chats.Helpers.Collections;

internal class ChatCollection : MongoDbCollection<Chat, ChatId>, IChatCollection
{
	private readonly IChatCacheHandler _cacheHandler;
	private readonly IChatFluentFactory _fluentFactory;
	private readonly IChatMessageCollection _messageCollection;

	public ChatCollection(
		ISessionHandler sessionHandler,
		IChatCacheHandler cacheHandler,
		IChatFluentFactory fluentFactory,
		IMongoCollection<Chat> collection,
		IChatMessageCollection messageCollection) : base(sessionHandler, collection)
	{
		_cacheHandler = cacheHandler;
		_fluentFactory = fluentFactory;
		_messageCollection = messageCollection;
	}

	public IChatFluent AggregateFluent()
	{
		var fluent = AggregateWithIgnoreCaseCollation();

		return _fluentFactory.Create(fluent);
	}

	public async Task AddAsync(
		Chat entity,
		CancellationToken cancellationToken)
	{
		await _messageCollection.CascadeAddAsync(entity.Id.GetChatMessageCascadeFilter(), cancellationToken);
		await InsertAsync(entity, cancellationToken);
		await _cacheHandler.DeleteAsync(entity.Id);
	}

	public async Task CascadeAddAsync(
		FilterDefinition<Chat> filter,
		CancellationToken cancellationToken)
	{
		await CascadeUpdateAsync(filter, cancellationToken);
	}

	public async Task AddRangeAsync(
		IEnumerable<Chat> entities,
		CancellationToken cancellationToken)
	{
		await _messageCollection.CascadeAddAsync(entities.Select(p => p.Id).GetChatMessageCascadeFilter(), cancellationToken);
		await InsertRangeAsync(entities, cancellationToken);
		await _cacheHandler.DeleteRangeAsync(entities.Select(p => p.Id));
	}

	public async Task CascadeUpdateAsync(
		FilterDefinition<Chat> filter,
		CancellationToken cancellationToken)
	{
		var chatIds = await GetIdsAsync(filter, cancellationToken);

		await _messageCollection.CascadeUpdateAsync(chatIds.GetChatMessageCascadeFilter(), cancellationToken);
		await _cacheHandler.DeleteRangeAsync(chatIds);
	}

	public async Task DeleteAsync(
		Chat entity,
		CancellationToken cancellationToken)
	{
		await _messageCollection.CascadeDeleteAsync(entity.Id.GetChatMessageCascadeFilter(), cancellationToken);
		await RemoveAsync(entity.Id.GetFilter(), cancellationToken);
		await _cacheHandler.DeleteAsync(entity.Id);
	}

	public async Task CascadeDeleteAsync(
		FilterDefinition<Chat> filter,
		CancellationToken cancellationToken)
	{
		var chatIds = await GetIdsAsync(filter, cancellationToken);

		await _messageCollection.CascadeDeleteAsync(chatIds.GetChatMessageCascadeFilter(), cancellationToken);
		await RemoveRangeAsync(filter, cancellationToken);
		await _cacheHandler.DeleteRangeAsync(chatIds);
	}
}
